using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace CarryBuddy.Updater
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
           InitializeComponent();
           string server = "REDACTED";




            var dir = AppDomain.CurrentDomain.BaseDirectory;
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileAsync(new Uri(server), dir + "\\CarryBuddy_UPT.exe");
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += wc_DownloadFileCompleted;
            }

            
          
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // In case you don't have a progressBar Log the value instead 
            // Console.WriteLine(e.ProgressPercentage);
            metroProgressBar1.Value = e.ProgressPercentage;
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            File.Delete(dir + "\\" + "CarryBuddy.exe");
            File.Move(dir + "\\CarryBuddy_UPT.exe", dir + "\\CarryBuddy.exe");
            Process.Start(dir + "\\CarryBuddy.exe");
            int nProcessID = Process.GetCurrentProcess().Id;
            string pid = nProcessID.ToString();
            Process.GetProcessById(Convert.ToInt32(pid)).Kill();

        }

        private void minimisebtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
