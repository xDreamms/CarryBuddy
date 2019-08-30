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
using System.Reflection;
using System.IO;
using System.Diagnostics;
namespace CarryBuddy.Loader.ViewModels
{
    public partial class Main : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        
        Modules.Injector Injector = new Modules.Injector();
        Modules.Debugger debugger = new Modules.Debugger();

        public Main()
        {
            InitializeComponent();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitialiseDesigns();
            Modules.Sandbox.SetScriptPermissions();
        }

        public void InitialiseDesigns()
        {
            var ButtonColor = Color.FromArgb(18, 24, 31);
            var TransparentColor = Color.FromArgb(0, 255, 255, 255);
            var BorderColor = Color.FromArgb(50, 202, 209);

            this.BackColor = Color.FromArgb(14, 19, 26);
            this.TopMenuBar.BackColor = ButtonColor;
            this.BottomFooter.BackColor = ButtonColor;

            this.CloseButton.BackColor = ButtonColor;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatAppearance.BorderColor = TransparentColor;

            this.MaximiseButton.BackColor = ButtonColor;
            this.MaximiseButton.FlatAppearance.BorderSize = 0;
            this.MaximiseButton.FlatAppearance.BorderColor = TransparentColor;

            this.MinimiseButton.BackColor = ButtonColor;
            this.MinimiseButton.FlatAppearance.BorderSize = 0;
            this.MinimiseButton.FlatAppearance.BorderColor = TransparentColor;

            this.SettingsButton.BackColor = ButtonColor;
            this.SettingsButton.FlatAppearance.BorderSize = 0;
            this.SettingsButton.FlatAppearance.BorderColor = TransparentColor;

            this.InjectButton.FlatAppearance.BorderSize = 0;
            this.InjectButton.FlatAppearance.BorderColor = TransparentColor;

            this.VersionText.ForeColor = BorderColor;

            this.VersionText.Text = "Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            this.UsernameText.ForeColor = BorderColor;

            this.CarryBuddyText.ForeColor = BorderColor;
            if (Modules.Debugger.IsDebuggerOn == true)
            {
                this.UsernameText.Text = "Welcome Back " + "Test" + "!";
                this.UserPFPBox.Load("https://dejagerart.com/wp-content/uploads/2018/09/Test-Logo-Circle-black-transparent.png");
                return;
            }
            else
            {
                this.UsernameText.Text = "Welcome Back " + Properties.Settings.Default.Username + "!";
                this.UserPFPBox.Load($"{Properties.Settings.Default.UserIcon}");

            }
            

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

        private void MaximiseButton_Click(object sender, EventArgs e)
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

        private void MinimiseButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void InjectButton_Click(object sender, EventArgs e)
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            string scfolder = dir + "\\Scripts";
            if (IsDirectoryEmpty(scfolder))
            {
                MessageBox.Show("There is no scripts in the folder");
                return;
            }
            DirectoryInfo d = new DirectoryInfo(scfolder);
            FileInfo[] Files = d.GetFiles("*.dll");
            foreach (FileInfo file in Files)
            {

                Injector.Inject(file.Name); 

            }

            
        }

        public bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            ViewModels.Settings settings = new ViewModels.Settings();
            settings.Show();
        }
    }

}
