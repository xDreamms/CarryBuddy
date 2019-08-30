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
using System.Runtime.InteropServices;

namespace CarryBuddy.Updater
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitialiseDesign();
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
            label1.Text = "Downloading Updates: " + e.ProgressPercentage + "%";
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

        public void InitialiseDesign()
        {
            var ButtonColor = Color.FromArgb(18, 24, 31);
            var TransparentColor = Color.FromArgb(0, 255, 255, 255);
            var BorderColor = Color.FromArgb(50, 202, 209);

            this.BackColor = Color.FromArgb(14, 19, 26);
            this.TopMenuBar.BackColor = ButtonColor;
            this.CarryBuddyText.ForeColor = BorderColor;

            this.MinimiseButton.BackColor = ButtonColor;
            this.MinimiseButton.ForeColor = Color.White;
            this.MinimiseButton.FlatAppearance.BorderSize = 0;
            this.MinimiseButton.FlatAppearance.BorderColor = TransparentColor;

            this.label1.ForeColor = Color.White;
            this.label1.BackColor = TransparentColor;
        }

        private void MinimiseButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void TopMenuBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}
