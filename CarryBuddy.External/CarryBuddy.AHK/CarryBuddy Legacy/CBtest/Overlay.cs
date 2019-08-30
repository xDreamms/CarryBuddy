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

namespace CarryBuddy
{
    public partial class Overlay : Form
    {
        RECT rect;
        public const string HWND_Name = "League of Legends (TM) Client"; //League of Legends (TM) Client New Text Document.txt - Notepad
        IntPtr handle = FindWindow(null, HWND_Name);
        




        public struct RECT
        {
            public int left, top, right, bottom;
        }


        Graphics g;
        Pen Mypen = new Pen(Color.Red);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        public Overlay()
        {
            InitializeComponent();
            
        }

        private void Overlay_Load_1(object sender, EventArgs e)
        {

            if (!GetWindowRect(handle, out rect))
            {
                this.BackColor = Color.Wheat;
                this.TransparencyKey = Color.Wheat;
                this.TopMost = true;
                this.FormBorderStyle = FormBorderStyle.None;

                int initialStyle1 = GetWindowLong(this.Handle, -20);
                SetWindowLong(this.Handle, -20, initialStyle1 | 0x80000 | 0x20);

                // this.WindowState = FormWindowState.Maximized;
                this.Width = Screen.PrimaryScreen.WorkingArea.Width;

                this.Height = Screen.PrimaryScreen.WorkingArea.Height;

                this.Top = 0;

                this.Left = 0;
                return;
            }

            this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;

            int initialStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);

            GetWindowRect(handle, out rect);
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;

            this.Height = Screen.PrimaryScreen.WorkingArea.Height;

            this.Top = 0;

            this.Left = 0;
        }

        private void Overlay_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawRectangle(Mypen, 100, 100, 200, 200);

            // Create string to draw.
            String drawString = "CarryBuddy";

            // Create font and brush.
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Green);

            // Create point for upper-left corner of drawing.
            float x = 150.0F;
            float y = 50.0F;

           

            // Draw string to screen.
            g.DrawString(drawString, drawFont, drawBrush, x, y);
        }

        private void Overlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Members can't close - when force close Application.exit()
            if(CBtest.login.primG == "Members")
            {
                e.Cancel = true;
            }
        }
    }
}
