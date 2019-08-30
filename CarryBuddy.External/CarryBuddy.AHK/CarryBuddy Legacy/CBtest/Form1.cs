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


namespace CBtest
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {

        public Form1()
        {
            InitializeComponent();
            
            //Load AHK engine and initialise script
            var ahk = AutoHotkeyEngine.Instance;
            ahk.LoadFile("init.ahk");

            //Loading SDK on intialisation
            var main = AppDomain.CurrentDomain.BaseDirectory;
            var SDKfile = Directory.EnumerateFiles(main, "*CarryBuddySDK.ahk");
            Parallel.ForEach(SDKfile, (SDKFnc) =>
            {
                var SDKs = File.ReadAllText(SDKFnc);
                ahk.LoadScript(SDKs);
            });
          

            //Defining directory for scripts folder
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            string scfolder = dir + "\\scripts";

            //If there are no scripts, dont activate
            if (IsDirectoryEmpty(scfolder))
            {
                sclabel.Text = "No Scripts Available";
                actck.Enabled = false;
                return;
            }

    
        
            //Using Parallel approach
            //Find all ahk files in the scripts folder and extend it to the init script(the main script)
            var files = Directory.EnumerateFiles(scfolder, "*.ahk");
            Parallel.ForEach(files, (current) =>
            {
                var scripts = File.ReadAllText(current);
                ahk.LoadScript(scripts);
            });


            //List all the scripts on the sclabel
            DirectoryInfo d = new DirectoryInfo(scfolder);
            FileInfo[] Files = d.GetFiles("*.ahk");

           
            string str = "";
            foreach (FileInfo file in Files)
            {
            
                str = "\r\n" + "- " + file.Name;
       
            }
            sclabel.Text = str;

            // Output count of scripts
            int fCount = Directory.GetFiles(scfolder, "*.ahk").Length;
            scrcount.Text = fCount + " script(s) ready";

            //Suspend initially for activation - sleep mode
            ahk.Suspend();
            
            

          
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
    }
}
