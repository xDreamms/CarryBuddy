using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web.Script;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace CBtest
{

    public static class Globals
    {
        public const string version = "1.0.4"; 
        
    }

    class CBUpdate
    {
        
       
   
        public static void CheckUpdate() //Checking update inside of the app
        {
            

            using (WebClient webClient = new System.Net.WebClient())
            {
                WebClient n = new WebClient();
                var json = n.DownloadString("https://carrybuddy.net/test.json");
                string valueOriginal = Convert.ToString(json);
                var JSONObj = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(valueOriginal);

                

                if (!JSONObj["version"].Equals(Globals.version))
                {
                   
                        var dir = AppDomain.CurrentDomain.BaseDirectory;
                    int nProcessID = Process.GetCurrentProcess().Id;
                    string pid = nProcessID.ToString();
                    Process.Start(dir + "\\CB Updater.exe");
                    Process.GetProcessById(Convert.ToInt32(pid)).Kill();
                    
                    



                        


                }

             


            }


        }



      
    }

    
}
