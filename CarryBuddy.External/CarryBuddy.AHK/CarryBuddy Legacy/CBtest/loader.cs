using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoHotkey.Interop;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace CBtest
{

    public partial class loader : MetroFramework.Forms.MetroForm
    {

        public loader()
        {
            InitializeComponent();
            var browser = new WebBrowser();
            browser.Url = new Uri("[REDACTED]" + "[REDACTED]");
            browser.Parent = metroTabPage2;
            browser.Visible = true;
            browser.Dock = DockStyle.Fill;
            browser.IsWebBrowserContextMenuEnabled = false;
            browser.AllowWebBrowserDrop = false;

            try
            {
                var TryversionInfo = FileVersionInfo.GetVersionInfo(@"C:\Riot Games\League of Legends" + "\\LeagueClient.exe");
            }
            catch(FileNotFoundException Ex)
            {
                MetroFramework.MetroMessageBox.Show(this, @"Could not find League of Legends client at C:\Riot Games\League of Legends", "Error");
                actck.Enabled = false;
                sclabel.Text = "League of Legends client unavailable";
                vrlabel.Text = Globals.version + " (League of Legends: #???)";
                vrlabel.ForeColor = MetroFramework.MetroColors.Red;
                return;

            }
            var versionInfo = FileVersionInfo.GetVersionInfo(@"C:\Riot Games\League of Legends" + "\\LeagueClient.exe");
            string version = versionInfo.ProductVersion;
            vrlabel.Text = Globals.version + " (League of Legends: #" + version + ")";
            LeagueVersion.GetVersion();
            if (version != LeagueVersion.LoLVer && version != LeagueVersion.LoLHFVer)
            {
                vrlabel.ForeColor = MetroFramework.MetroColors.Red;
                actck.Enabled = false;
                sclabel.Text = "Please wait for the new CB update";
                
                return;

            }
            else
            {
                vrlabel.ForeColor = MetroFramework.MetroColors.Green;
            }

            
            


            /*
            CarryBuddy.Overlay ol = new CarryBuddy.Overlay();
            if (login.primG == "Members")
            {
                ol.Show();
            }
            */

            //Load AHK engine and initialise script
            var ahk = AutoHotkeyEngine.Instance;
            var main1 = AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                Decryptor.Init(main1 + "\\init.cb", "Secret");
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Error");
                Application.Exit();
            }

            try
            {
                Decryptor.SDK(main1 + "\\CarryBuddySDK.cb", "Secret");
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Error");
                Application.Exit();
            }


            //Loading SDK on intialisation
            ahk.LoadScript(DecryptionStorage.InitStorageValue);
            ahk.LoadScript(DecryptionStorage.SDKStorageValue);

            /*
            //Loading SDK on intialisation
            var main = AppDomain.CurrentDomain.BaseDirectory;
            var SDKfile = Directory.EnumerateFiles(main, "*CarryBuddySDK.ahk");
            Parallel.ForEach(SDKfile, (SDKFnc) =>
            {
                var SDKs = File.ReadAllText(SDKFnc);
                ahk.LoadScript(SDKs);
            });
          */







            //Defining directory for scripts folder
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            string scfolder = dir + "\\scripts";

            //If there are no scripts, dont activate
            if (IsDirectoryEmpty(scfolder))
            {
                sclabel.Text = "No Scripts Available";
                  scrcount.Text = "0 script ready";
                
                actck.Enabled = false;
                return;
            }

    
        
            //Using Parallel approach
            //Find all ahk files in the scripts folder and extend it to the init script(the main script)
            var files = Directory.EnumerateFiles(scfolder, "*.cbaddon");
            Parallel.ForEach(files, (current) =>
            {
                var scripts = File.ReadAllText(current);
               ahk.LoadScript(scripts);
            });


            //List all the scripts on the sclabel
            DirectoryInfo d = new DirectoryInfo(scfolder);
            FileInfo[] Files = d.GetFiles("*.cbaddon");

           
            string str = "";
            foreach (FileInfo file in Files)
            {
            
                str = "\r\n" + "- " + file.Name;
       
            }
            sclabel.Text = str;

            // Output count of scripts
            int fCount = Directory.GetFiles(scfolder, "*.cbaddon").Length;
           
            if (fCount.Equals(1))
            {
                scrcount.Text = fCount + " script ready";
            }

            if(fCount > 1)
            {
                scrcount.Text = fCount + " scripts ready";
            }

            
            //Suspend initially for activation - sleep mode
           ahk.Suspend();


            
        }

       

        public string welcome
        {
            get
            {
                return this.welctxt.Text;
            }
            set
            {
                this.welctxt.Text = value;
            }
        }

        public bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {

            var ahk = AutoHotkeyEngine.Instance;

            if (actck.Checked)
            {
                
                ahk.UnSuspend();
                labelact.Text = "Script Activated.";
            }
            if (!actck.Checked)
            {
                ahk.Suspend();
                labelact.Text = "";
            }

        }

        private void loader_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
        
    }
}
