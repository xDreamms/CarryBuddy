using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace CarryBuddy.Loader.Modules
{    
    class Sandbox
    {
        /// <summary>
        /// Set required permissions to every files in Scripts folder
        /// </summary>
        public static void SetScriptPermissions()
        {
            AppDomainSetup Setup = new AppDomainSetup
            {
                ApplicationName = "CBScriptContainer" + Guid.NewGuid().ToString("X") + "D",
                ApplicationBase = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Scripts"
            };
            PermissionSet permissions = new PermissionSet(PermissionState.Unrestricted);
            permissions.AddPermission(new EnvironmentPermission(EnvironmentPermissionAccess.Read, "USERNAME"));
            //permissions.AddPermission(new FileIOPermission(FileIOPermissionAccess.AllAccess, Assembly.GetExecutingAssembly().Location));
            permissions.AddPermission(new ReflectionPermission(PermissionState.Unrestricted));
            permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            //permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.Infrastructure));
            permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.RemotingConfiguration));
            permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.SerializationFormatter));
            permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.UnmanagedCode));
            permissions.AddPermission(new UIPermission(PermissionState.Unrestricted));
            permissions.AddPermission(new WebPermission(NetworkAccess.Connect, new Regex("https?:\\/\\/(\\w+)\\.carrybuddy\\.net\\/.*")));
            AppDomain.CreateDomain("ScriptContainer", null, Setup, permissions);
        }
    }
}
