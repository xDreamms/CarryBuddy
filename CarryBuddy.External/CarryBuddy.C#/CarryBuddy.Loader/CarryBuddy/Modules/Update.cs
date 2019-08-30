using System;
using System.Collections.Generic;
using System.Net;
using System.Diagnostics;
using System.Web.Script.Serialization;
using System.Reflection;


namespace CarryBuddy.Modules
{
    class Update
    {
        public static void CheckUpdate() //Checking update inside of the app
        {
            using (WebClient webClient = new System.Net.WebClient())
            {
                WebClient n = new WebClient();
                var json = n.DownloadString("REDACTED");
                string valueOriginal = Convert.ToString(json);
                var JSONObj = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(valueOriginal);

                if (!JSONObj["LoaderVersion"].Equals(Assembly.GetExecutingAssembly().GetName().Version))
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
