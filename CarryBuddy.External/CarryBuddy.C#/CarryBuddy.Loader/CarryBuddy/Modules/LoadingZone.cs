using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace CarryBuddy.Modules
{
    class LoadingZone
    {
        public static void LoadScript()
        {
            var main = AppDomain.CurrentDomain.BaseDirectory;
            List<byte[]> scbyte = new List<byte[]>();
            var scroot = main + "\\scripts";
            //Loading scripts
            string scfolder = main + "\\scripts";

            //If there are no scripts, dont activate
            if (IsDirectoryEmpty(scfolder))
            {
                MessageBox.Show("No Scripts!");
                return;
            }
            var files = Directory.EnumerateFiles(scroot, "*.dll");
            Parallel.ForEach(files, (current) =>
            {
                var scripts = File.ReadAllBytes(current);
                scbyte.Add(scripts);
                Modules.Sandbox.Load(scbyte);
                

            });
            //MessageBox.Show("Script Activated");
            //Need a logging function
        }


        /*
        public static bool isSDKLoaded = false;
        public static void LoadSDK()
        {
            if (isSDKLoaded == true)
            {
                MessageBox.Show("SDK is already loaded!");
                return;
            }

            if (isSDKLoaded == false)
            {
                var main = AppDomain.CurrentDomain.BaseDirectory;
                // Create a new WebClient instance.
                WebClient myWebClient = new WebClient();
                // Download the Web resource and save it into a data buffer.
                byte[] SDKBuffer = myWebClient.DownloadData("REDACTED");
                Modules.Sandbox.Initialize(SDKBuffer);
                //Need a logging function
                isSDKLoaded = true;

            }
        }
        */


        public static bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }
    }

}
