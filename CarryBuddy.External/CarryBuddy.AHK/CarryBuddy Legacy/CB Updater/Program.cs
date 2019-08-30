using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Net;
namespace CB_Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            string server = "REDACTED";

         

            
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(server, dir + "\\CB_New.exe");
            }

            File.Delete(dir + "\\" + "Carrybuddy.exe");
            File.Move(dir + "\\CB_New.exe", dir + "\\Carrybuddy.exe");
            Process.Start(dir + "\\Carrybuddy.exe");
            int nProcessID = Process.GetCurrentProcess().Id;
            string pid = nProcessID.ToString();
            Process.GetProcessById(Convert.ToInt32(pid)).Kill();

        }
    }
}
