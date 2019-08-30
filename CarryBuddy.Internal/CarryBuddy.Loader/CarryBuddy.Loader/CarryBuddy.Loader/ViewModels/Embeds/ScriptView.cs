using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace CarryBuddy.Loader.ViewModels.Embeds
{
    public partial class ScriptView : UserControl
    {
        public ScriptView()
        {
            InitializeComponent();
        }

        private void ScriptView_Load(object sender, EventArgs e)
        {
            InitialiseDesign();
            DisplayScripts();
        }

        public void InitialiseDesign()
        {
            var ButtonColor = Color.FromArgb(18, 24, 31);
            var TransparentColor = Color.FromArgb(0, 255, 255, 255);
            var BorderColor = Color.FromArgb(50, 202, 209);

            this.BackColor = Color.FromArgb(18, 24, 31);

            this.MainText.ForeColor = Color.White;

            this.ScriptListView.BackColor = BorderColor;
        }

        public void DisplayScripts()
        {
            var main = AppDomain.CurrentDomain.BaseDirectory;
            var scroot = main + "\\Scripts";

            //List all the scripts on the listview
            DirectoryInfo d = new DirectoryInfo(scroot);

            try
            {
                FileInfo[] Files = d.GetFiles("*.dll");


                string str = "";
                foreach (FileInfo file in Files)
                {
                    FileVersionInfo ScriptInfo = FileVersionInfo.GetVersionInfo(scroot + $"\\{file.Name}");
                    str = "\r\n" + file.Name.Replace(".dll", "");
                    ListViewItem item = new ListViewItem(str);
                    item.SubItems.Add(ScriptInfo.ProductVersion);
                    ScriptListView.Items.Add(item);
                }
            }
            catch(Exception e)
            {

            }
        }

        private void ScriptListView_Resize(object sender, EventArgs e)
        {
            this.Version.Width = Right;
        }
    }
}
