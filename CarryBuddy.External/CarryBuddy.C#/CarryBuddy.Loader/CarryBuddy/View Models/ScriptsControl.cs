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

namespace CarryBuddy.View_Models
{
    public partial class ScriptsControl : MetroFramework.Controls.MetroUserControl
    {
        public ScriptsControl()
        {
            
            InitializeComponent();
            PathCol.Width = Width; 
            var main = AppDomain.CurrentDomain.BaseDirectory;
            var scroot = main + "\\scripts";

            //List all the scripts on the listview
            DirectoryInfo d = new DirectoryInfo(scroot);
            FileInfo[] Files = d.GetFiles("*.dll");


            string str = "";
            foreach (FileInfo file in Files)
            {

                str = "\r\n" + file.Name.Replace(".dll", "");
                ListViewItem item = new ListViewItem(str);
                item.SubItems.Add(file.FullName.ToString());
                ScriptLV.Items.Add(item);
            }

            


        }

        

        private void ScriptLV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ScriptLV_Resize(object sender, EventArgs e)
        {
            PathCol.Width = Width;

        }
    }
}
