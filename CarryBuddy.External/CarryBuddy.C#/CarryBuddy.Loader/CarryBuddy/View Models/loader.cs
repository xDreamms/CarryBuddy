using System;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace CarryBuddy
{

    public partial class loader : MetroFramework.Forms.MetroForm
    {

        public loader()
        {

            InitializeComponent();
            minimisebtn.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            closebtn.FlatAppearance.BorderSize = 0;
            Activatebtn.Hide();
            //MessageBox.Show(CarryBuddy.Modules.login.PFP);
            string strm = CarryBuddy.Modules.login.PFP.ToString();
            pictureBox1.Load(CarryBuddy.Modules.login.PFP.ToString());
            versionlabel.Text = Modules.Globals.version;
            settingbtn.Hide();
        }



        private void loader_Load(object sender, EventArgs e)
        {
            newsControl1.BringToFront();

        }


        
        

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


       

        private void minimisebtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                return;
            }

            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Newsbtn_Click(object sender, EventArgs e)
        {
            newsControl1.BringToFront();
        }
        bool isActivated = false;
        private void scriptsbtn_Click(object sender, EventArgs e)
        {
            scriptsControl2.BringToFront();
            if(isActivated == false)
            {
                Activatebtn.Show();
                Activatebtn.Enabled = true;
                isActivated = true;
                return;
            }
            
        }

        private void settingbtn_Click(object sender, EventArgs e)
        {
            CarryBuddy.View_Models.setting setting = new CarryBuddy.View_Models.setting();
            if (setting.Visible)
            {
                return;
            }
            else
            {
                setting.Show();
            }
            
        }

        private void metroPanel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                return;
            }

            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            


            /*
            SDK.Utilities.System.Sleep(2000);

            while (SDK.UnitsManager.GetDistanceBetweenPlayerAndEnemy() > 550)
            {
                continue;
            }

            if (SDK.UnitsManager.AttackEnemy())
            {
                SDK.Items.UseItem(SDK.Items.GetItemSlot(SDK.Items.ITEM_BLADE_OF_THE_RUINED_KING_RGB_PIXEL_COLOR));
                SDK.Items.UseItem(SDK.Items.GetItemSlot(SDK.Items.ITEM_BILGEWATER_CUTLASS_RGB_PIXEL_COLOR));
                SDK.Items.UseItem(SDK.Items.GetItemSlot(SDK.Items.ITEM_YOUMUUS_GHOSTBLADE_RGB_PIXEL_COLOR));
                SDK.Items.UseItem(SDK.Items.GetItemSlot(SDK.Items.ITEM_REFILLABLE_POTION_RGB_PIXEL_COLOR));
                SDK.Skills.CastR();
                SDK.Skills.CastE();
                SDK.Skills.CastQ();
                SDK.Utilities.System.Sleep(1500);
                SDK.Skills.CastW();
                SDK.Utilities.System.Sleep(200);
                SDK.UnitsManager.AttackEnemy();
                SDK.Items.UseItem(SDK.Items.GetItemSlot(SDK.Items.ITEM_TIAMAT_RGB_PIXEL_COLOR));
                SDK.Items.UseItem(SDK.Items.GetItemSlot(SDK.Items.ITEM_RAVENOUS_HYDRA_RGB_PIXEL_COLOR));
                SDK.Utilities.System.Sleep(200);

                while (SDK.MouseEvents.MoveMouseToPixelCoordsWithOffset(SDK.UnitsManager.RGB_ENEMY_LEVEL_COLOR, 50, 0))
                {
                    if (SDK.UnitsManager.GetDistanceBetweenPlayerAndEnemy() <= 110)
                    {
                        SDK.MouseEvents.MouseClickRight();
                        SDK.Utilities.System.Sleep(400);
                    }

                    SDK.UnitsManager.AttackEnemy();
                    SDK.Utilities.System.Sleep(400);
                    SDK.Items.UseItem(SDK.Items.GetItemSlot(SDK.Items.ITEM_TIAMAT_RGB_PIXEL_COLOR));
                    SDK.Items.UseItem(SDK.Items.GetItemSlot(SDK.Items.ITEM_RAVENOUS_HYDRA_RGB_PIXEL_COLOR));

                    if (!SDK.Skills.QIsOnCooldown())
                    {
                        SDK.UnitsManager.AttackEnemy();
                        SDK.Skills.CastQ();
                        SDK.Utilities.System.Sleep(1500);
                    }
                }
            }*/
        }


        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void metroPanel1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        
        private void Activatebtn_Click(object sender, EventArgs e)
        {
            Modules.LoadingZone.LoadScript();
            Activatebtn.Enabled = false;
            isActivated = true;
        }

        public bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }
    }

}


