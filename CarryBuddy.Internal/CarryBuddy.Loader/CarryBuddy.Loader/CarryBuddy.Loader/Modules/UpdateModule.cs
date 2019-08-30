using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using System.Web.Script.Serialization;
using System.Reflection;
namespace CarryBuddy.Loader.Modules
{
    class UpdateModule
    {
        /// <summary>
        /// Check [LoaderVersion] of LoaderVersion.json matches our assembly version
        /// </summary>
        public static void CheckUpdate()
        {
            using (WebClient webClient = new System.Net.WebClient())
            {
                WebClient n = new WebClient();
                var json = n.DownloadString("REDACTED");
                string valueOriginal = Convert.ToString(json);
                var JSONObj = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(valueOriginal);

                if (!JSONObj["LoaderVersion"].Equals(Assembly.GetExecutingAssembly().GetName().Version.ToString()))
                {
                    var dir = AppDomain.CurrentDomain.BaseDirectory;
                    int nProcessID = Process.GetCurrentProcess().Id;
                    string pid = nProcessID.ToString();
                    Process.Start(dir + "\\CarryBuddy Updater.exe");
                    Process.GetProcessById(Convert.ToInt32(pid)).Kill();
                }


            }
        }
    }
}
