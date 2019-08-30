using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CarryBuddy.Loader.ViewModels
{
    public partial class Settings : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        ViewModels.Main main = new ViewModels.Main();

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            InitialiseDesign();
        }

        public void InitialiseDesign()
        {
            var ButtonColor = Color.FromArgb(18, 24, 31);
            var TransparentColor = Color.FromArgb(0, 255, 255, 255);
            var BorderColor = Color.FromArgb(50, 202, 209);

            this.BackColor = Color.FromArgb(14, 19, 26);
            this.TopMenuBar.BackColor = ButtonColor;
            this.CarryBuddyText.ForeColor = BorderColor;

            this.CloseButton.BackColor = ButtonColor;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatAppearance.BorderColor = TransparentColor;

            this.MinimiseButton.BackColor = ButtonColor;
            this.MinimiseButton.FlatAppearance.BorderSize = 0;
            this.MinimiseButton.FlatAppearance.BorderColor = TransparentColor;

            this.UserDetailsCheckbox.ForeColor = BorderColor;
            this.SplashCheckbox.ForeColor = BorderColor;

            this.SplashCheckbox.Checked = Properties.Settings.Default.SplashScreen;
        }

        private void MinimiseButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TopMenuBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void UserDetailsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if(UserDetailsCheckbox.Checked == false)
            {
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.UserIcon = "";
                Properties.Settings.Default.Save();
            }
        }

        private void SplashCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if(SplashCheckbox.Checked == false)
            {
                Properties.Settings.Default.SplashScreen = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.SplashScreen = true;
                Properties.Settings.Default.Save();
            }
        }
    }
}
