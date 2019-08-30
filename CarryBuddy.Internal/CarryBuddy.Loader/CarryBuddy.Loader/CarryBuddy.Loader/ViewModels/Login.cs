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
using MySql.Data.MySqlClient;
using System.Threading;

namespace CarryBuddy.Loader.ViewModels
{
    public partial class Login : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        Modules.LoginModule LModule = new Modules.LoginModule();
        Modules.Startup SModule = new Modules.Startup();

        public Login()
        {
            SModule.ShowSplash();
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            InitialiseDesigns();
        }

        public void InitialiseDesigns()
        {
            var ButtonColor = Color.FromArgb(18, 24, 31);
            var TransparentColor = Color.FromArgb(0, 255, 255, 255);
            var BorderColor = Color.FromArgb(50, 202, 209);

            this.BackColor = Color.FromArgb(14, 19, 26);
            this.TopMenuBar.BackColor = ButtonColor;
            this.CarryBuddyText.ForeColor = BorderColor;
            this.WelcomeLabel.ForeColor = BorderColor;
            this.ErrorText.ForeColor = Color.White;
            this.ErrorText.Text = "";

            this.CloseButton.BackColor = ButtonColor;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatAppearance.BorderColor = TransparentColor;

            this.MinimiseButton.BackColor = ButtonColor;
            this.MinimiseButton.ForeColor = Color.White;
            this.MinimiseButton.FlatAppearance.BorderSize = 0;
            this.MinimiseButton.FlatAppearance.BorderColor = TransparentColor;

            this.UsernameLabel.ForeColor = BorderColor;
            this.PasswordLabel.ForeColor = BorderColor;

            this.UsernameBox.BackColor = ButtonColor;
            this.UsernameBox.ForeColor = BorderColor;

            this.PasswordBox.BackColor = ButtonColor;
            this.PasswordBox.ForeColor = BorderColor;

            this.LoginButton.BackColor = ButtonColor;
            this.LoginButton.ForeColor = BorderColor;
            this.LoginButton.FlatAppearance.BorderColor = BorderColor;
            this.LoginButton.FlatAppearance.BorderSize = 1;

        }

        private void TopMenuBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimiseButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            if (UsernameBox.Text.Length == 0 && PasswordBox.Text.Length == 0)
            {
                this.ErrorText.Text = "Please Enter Username and Password";
                return;
            }

            if (UsernameBox.Text.Length == 0)
            {
                this.ErrorText.Text = "Please Enter Username";
                return;
            }

            if(PasswordBox.Text.Length == 0)
            {
                this.ErrorText.Text = "Please Enter Password";
                return;
            }

                LModule.SetUserDetails(UsernameBox.Text);
                LModule.PasswordChecker(UsernameBox.Text, PasswordBox.Text);
                this.ErrorText.Text = "Checking For Account...";
                this.LoginButton.Enabled = false;
                await Task.Delay(4100);
                if(Modules.LoginModule.IfPasswordisTrue == true)
                {
                Properties.Settings.Default.Username = UsernameBox.Text;
                Properties.Settings.Default.Password = PasswordBox.Text;
                Properties.Settings.Default.Save();
                Main main = new Main();
                    this.Hide();
                    main.Show();
                    return;
                }
                else
                {
                    this.LoginButton.Enabled = true;
                    this.ErrorText.Text = "Wrong Username or Password";
                    this.LoginButton.Enabled = true;
                    return;
                }
            
            
        }

        private void ErrorText_SizeChanged(object sender, EventArgs e)
        {
            if(this.ErrorText.Text.Length == 26)
            {
                this.ErrorText.Location = new Point(88, 102);
            }

            if (this.ErrorText.Text.Length == 34)
            {
               this.ErrorText.Location = new Point(68, 102);
            }

            if (this.ErrorText.Text.Length == 21)
            {
                this.ErrorText.Location = new Point(115, 102);
            }

            if (this.ErrorText.Text.Length == 30)
            {
                this.ErrorText.Location = new Point(85, 102);
            }

            if (this.ErrorText.Text.Length == 28)
            {
                this.ErrorText.Location = new Point(87, 102);
            }

            if (this.ErrorText.Text.Length == 23)
            {
                this.ErrorText.Location = new Point(113, 102);
            }

        }
    }
}
