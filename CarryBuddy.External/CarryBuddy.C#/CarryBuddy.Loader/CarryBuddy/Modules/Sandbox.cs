using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Text.RegularExpressions;

namespace CarryBuddy.Modules
{
    internal static class Sandbox
    {
        private static List<byte[]> Running { get; set; } = new List<byte[]>();

        /// <summary>
        /// Loads and executes our scripts.
        /// </summary>
        /// <param name="Scripts">a list of scripts in byte[] we wan't to load.</param>
        /// <returns>a boolean whether or not our scripts could be loaded successfully. Note: this still returns true if some scripts couldn't be loaded or executed.</returns>
        public static bool Load(List<byte[]> Scripts)
        {
            if (Handle == null || Execute == null) //check if our AppDomain and our Executer have been Created. If not try to create them.
            {
                var Result = Create();
                if (Result == false) //check if the creation was successful. if not return as we can't load our scripts without the AppDomain or Executer.
                    return false;
            }

            for (int i = 0; i < Scripts.Count; i++)
            {
                if (Running.Any(x => x.SequenceEqual(Scripts[i]))) //tried to load a script that was already loaded.
                    continue;

                //loads the script / assembly from an array of bytes and executes it. 
                //the method that should be executed has to have the STAThreadAttribute currently. 
                //note: the first method it can find containing this attribute will be executed.
                //note: if there is no method to be found containing the attribute the assembly will still count as loaded but the script won't be executed.
                var Result = Execute.LoadAndExecute(Scripts[i]);
                if (Result != ScriptLoadResult.Successful)
                {
                    if (Result == ScriptLoadResult.Failed)
                        Console.WriteLine("Failed to Load Script. [" + i + " / " + Scripts.Count + "]"); //Exchange with proper server log at some point.
                    if (Result == ScriptLoadResult.Partial)
                        Console.WriteLine("the script was successfully loaded, but could not be exectued. [" + i + " / " + Scripts.Count + "]" + "\r\nReason: unable to locate EntryPoint."); //Exchange with proper server log at some point.
                }
                Running.Add(Scripts[i]); //contains a list of byte[] that have been loaded. this is mostly used for reloading and to prevent loading the same script twice.
            }
            return true;
        }

        /// <summary>
        /// Unloads our currently loaded scripts.
        /// </summary>
        /// <returns>a boolean indicating whether or not the reload was successful</returns>
        public static bool Unload()
        {
            if (Handle != null && Execute != null) //check if our AppDomain and Executer haven't been Unloaded before. if not, unload them.
            {
                AppDomain.Unload(Handle);
                Execute = null;
                Running = new List<byte[]>();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Reloads our currently loaded scripts.
        /// </summary>
        /// <returns>a boolean indicating whether or not the reload was successful.</returns>
        public static bool Reload()
        {
            var Scripts = Running; //Copy the list of currently running scripts as they're being emptied on Unload.
            if (Scripts.Count > 0 && Unload()) //Check if we have any scripts loaded, if we do unload them and reload them.
                return Load(Scripts); //aaand reload our previously scripts.
            else
                return false;
        }

        private static bool Create()
        {
            AppDomainSetup Setup = new AppDomainSetup
            {
                ApplicationName = "CBScriptContainer" + Guid.NewGuid().ToString("X") + "D",
                ApplicationBase = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\"
            };
            PermissionSet permissions = new PermissionSet(PermissionState.Unrestricted);
            permissions.AddPermission(new EnvironmentPermission(EnvironmentPermissionAccess.Read, "USERNAME"));
            permissions.AddPermission(new FileIOPermission(FileIOPermissionAccess.AllAccess, Assembly.GetExecutingAssembly().Location));
            permissions.AddPermission(new ReflectionPermission(PermissionState.Unrestricted));
            permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.Infrastructure));
            permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.RemotingConfiguration));
            permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.SerializationFormatter));
            permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.UnmanagedCode));
            permissions.AddPermission(new UIPermission(PermissionState.Unrestricted));
            permissions.AddPermission(new WebPermission(NetworkAccess.Connect, new Regex("https?:\\/\\/(\\w+)\\.carrybuddy\\.net\\/.*")));
            Handle = AppDomain.CreateDomain("ScriptContainer", null, Setup, permissions);
            Execute = (Executer)Activator.CreateInstanceFrom(Handle, Assembly.GetExecutingAssembly().Location, typeof(Executer).FullName).Unwrap();
            Execute.AttachToResolve(new ResolveEventHandler(Resolver));
            return (Execute != null && Handle != null);
        }

        private static Assembly Resolver(object Sender, ResolveEventArgs e)
        {
            if (e.Name.Contains("CarryBuddy.SDK"))
                return ((AppDomain)Sender).Load(new WebClient().DownloadData("REDACTED"));
            else if (e.Name.Contains(typeof(Sandbox).Assembly.GetName().Name))
                return typeof(Sandbox).Assembly;
            return null;
        }

        private static AppDomain Handle { get; set; } = null;
        private static Executer Execute { get; set; }

        private class Executer : MarshalByRefObject
        {
            /// <summary>
            /// Loads a single scripts / assembly.
            /// </summary>
            /// <param name="e">the byte array of the scripts / assembly.</param>
            /// <param name="Asm">the variable that should hold the Assembly after Loading it.</param>
            /// <returns>a boolean indicating whether or not the script could be executed succesfully.</returns>
            public ScriptLoadResult LoadAndExecute(byte[] e)
            {
                var Asm = Assembly.Load(e);
                if (Asm != null)
                {
                    foreach (var T in Asm.GetTypes())
                    {
                        var M = T.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                        for (int ii = 0; ii < M.Length; ii++)
                        {
                            foreach (var Att in M[ii].CustomAttributes)
                            {
                                if (Att.AttributeType.Name == "CBEntryPoint")
                                {
                                    M[ii].Invoke(null, null);
                                    return ScriptLoadResult.Successful;
                                }
                            }
                        }
                    }
                    return ScriptLoadResult.Partial;
                }
                return ScriptLoadResult.Failed;
            }

            /// Self explanatory.
            public void AttachToResolve(ResolveEventHandler e)
            {
                AppDomain.CurrentDomain.AssemblyResolve += e;
                AppDomain.CurrentDomain.AssemblyResolve += Resolver;
            }

            private static Assembly Resolver(object Sender, ResolveEventArgs e)
            {
                var ProperName = e.Name.Split(',')[0];
                if (Loaded.ContainsKey(ProperName))
                    return Loaded[e.Name];
                return null;
            }

            public override object InitializeLifetimeService()
            {
                return null;
            }

            private static Dictionary<string, Assembly> Loaded { get; set; }
        }

        private enum ScriptLoadResult : int
        {
            Successful,
            Partial,
            Failed,
        }

        static Sandbox()
        {
            AppDomain.CurrentDomain.AssemblyResolve += Resolver;
        }
    }
}