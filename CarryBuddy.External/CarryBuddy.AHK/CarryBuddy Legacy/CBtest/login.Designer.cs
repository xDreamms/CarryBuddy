namespace CBtest
{
    partial class login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.uname = new MetroFramework.Controls.MetroTextBox();
            this.password = new MetroFramework.Controls.MetroTextBox();
            this.forgotpwd = new MetroFramework.Controls.MetroLabel();
            this.createacc = new MetroFramework.Controls.MetroLabel();
            this.loginbtn = new MetroFramework.Controls.MetroButton();
            this.error = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uname
            // 
            // 
            // 
            // 
            this.uname.CustomButton.Image = null;
            this.uname.CustomButton.Location = new System.Drawing.Point(272, 1);
            this.uname.CustomButton.Name = "";
            this.uname.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.uname.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.uname.CustomButton.TabIndex = 1;
            this.uname.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.uname.CustomButton.UseSelectable = true;
            this.uname.CustomButton.Visible = false;
            this.uname.DisplayIcon = true;
            this.uname.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.uname.Icon = ((System.Drawing.Image)(resources.GetObject("uname.Icon")));
            this.uname.IconRight = true;
            this.uname.Lines = new string[0];
            this.uname.Location = new System.Drawing.Point(23, 123);
            this.uname.MaxLength = 32767;
            this.uname.Name = "uname";
            this.uname.PasswordChar = '\0';
            this.uname.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.uname.SelectedText = "";
            this.uname.SelectionLength = 0;
            this.uname.SelectionStart = 0;
            this.uname.ShortcutsEnabled = true;
            this.uname.Size = new System.Drawing.Size(306, 35);
            this.uname.TabIndex = 0;
            this.uname.UseSelectable = true;
            this.uname.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.uname.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // password
            // 
            // 
            // 
            // 
            this.password.CustomButton.Image = null;
            this.password.CustomButton.Location = new System.Drawing.Point(272, 1);
            this.password.CustomButton.Name = "";
            this.password.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.password.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.password.CustomButton.TabIndex = 1;
            this.password.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.password.CustomButton.UseSelectable = true;
            this.password.CustomButton.Visible = false;
            this.password.DisplayIcon = true;
            this.password.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.password.Icon = ((System.Drawing.Image)(resources.GetObject("password.Icon")));
            this.password.IconRight = true;
            this.password.Lines = new string[0];
            this.password.Location = new System.Drawing.Point(23, 194);
            this.password.MaxLength = 32767;
            this.password.Name = "password";
            this.password.PasswordChar = '●';
            this.password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.password.SelectedText = "";
            this.password.SelectionLength = 0;
            this.password.SelectionStart = 0;
            this.password.ShortcutsEnabled = true;
            this.password.Size = new System.Drawing.Size(306, 35);
            this.password.TabIndex = 1;
            this.password.UseSelectable = true;
            this.password.UseSystemPasswordChar = true;
            this.password.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.password.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // forgotpwd
            // 
            this.forgotpwd.AutoSize = true;
            this.forgotpwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.forgotpwd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.forgotpwd.Location = new System.Drawing.Point(23, 263);
            this.forgotpwd.Name = "forgotpwd";
            this.forgotpwd.Size = new System.Drawing.Size(144, 19);
            this.forgotpwd.TabIndex = 2;
            this.forgotpwd.Text = "Forgot your password?";
            this.forgotpwd.Click += new System.EventHandler(this.forgotpwd_Click);
            // 
            // createacc
            // 
            this.createacc.AutoSize = true;
            this.createacc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createacc.Location = new System.Drawing.Point(23, 292);
            this.createacc.Name = "createacc";
            this.createacc.Size = new System.Drawing.Size(99, 19);
            this.createacc.TabIndex = 3;
            this.createacc.Text = "Create Account";
            this.createacc.Click += new System.EventHandler(this.createacc_Click);
            // 
            // loginbtn
            // 
            this.loginbtn.BackColor = System.Drawing.Color.White;
            this.loginbtn.ForeColor = System.Drawing.Color.Black;
            this.loginbtn.Location = new System.Drawing.Point(116, 338);
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Size = new System.Drawing.Size(121, 39);
            this.loginbtn.TabIndex = 4;
            this.loginbtn.Text = "LOG IN";
            this.loginbtn.UseCustomBackColor = true;
            this.loginbtn.UseCustomForeColor = true;
            this.loginbtn.UseSelectable = true;
            this.loginbtn.UseStyleColors = true;
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            this.loginbtn.MouseLeave += new System.EventHandler(this.loginbtn_MouseLeave);
            this.loginbtn.MouseHover += new System.EventHandler(this.loginbtn_MouseHover);
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.error.ForeColor = System.Drawing.Color.Red;
            this.error.Location = new System.Drawing.Point(51, 92);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(0, 16);
            this.error.TabIndex = 5;
            this.error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 400);
            this.Controls.Add(this.error);
            this.Controls.Add(this.loginbtn);
            this.Controls.Add(this.createacc);
            this.Controls.Add(this.forgotpwd);
            this.Controls.Add(this.password);
            this.Controls.Add(this.uname);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "login";
            this.Resizable = false;
            this.Text = "CarryBuddy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox uname;
        private MetroFramework.Controls.MetroTextBox password;
        private MetroFramework.Controls.MetroLabel forgotpwd;
        private MetroFramework.Controls.MetroLabel createacc;
        private MetroFramework.Controls.MetroButton loginbtn;
        private System.Windows.Forms.Label error;
    }
}