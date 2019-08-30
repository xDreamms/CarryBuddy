namespace CarryBuddy.Modules
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
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.closebtn = new System.Windows.Forms.Button();
            this.minimisebtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.usernametxt = new MetroFramework.Controls.MetroTextBox();
            this.passwordtxt = new MetroFramework.Controls.MetroTextBox();
            this.loginbtn = new System.Windows.Forms.Button();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.rememberbox = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.error = new System.Windows.Forms.Label();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel2
            // 
            this.metroPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(166)))), ((int)(((byte)(209)))));
            this.metroPanel2.Controls.Add(this.closebtn);
            this.metroPanel2.Controls.Add(this.minimisebtn);
            this.metroPanel2.Controls.Add(this.label1);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, -1);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(392, 70);
            this.metroPanel2.TabIndex = 0;
            this.metroPanel2.UseCustomBackColor = true;
            this.metroPanel2.UseCustomForeColor = true;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            this.metroPanel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.metroPanel2_MouseDown);
            // 
            // closebtn
            // 
            this.closebtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.closebtn.FlatAppearance.BorderSize = 0;
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.ForeColor = System.Drawing.Color.White;
            this.closebtn.Location = new System.Drawing.Point(315, 0);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(77, 70);
            this.closebtn.TabIndex = 8;
            this.closebtn.Text = "x";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // minimisebtn
            // 
            this.minimisebtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.minimisebtn.FlatAppearance.BorderSize = 0;
            this.minimisebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimisebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimisebtn.ForeColor = System.Drawing.Color.White;
            this.minimisebtn.Location = new System.Drawing.Point(241, 0);
            this.minimisebtn.Name = "minimisebtn";
            this.minimisebtn.Size = new System.Drawing.Size(77, 70);
            this.minimisebtn.TabIndex = 7;
            this.minimisebtn.Text = "-";
            this.minimisebtn.UseVisualStyleBackColor = true;
            this.minimisebtn.Click += new System.EventHandler(this.minimisebtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "CARRYBUDDY";
            // 
            // usernametxt
            // 
            // 
            // 
            // 
            this.usernametxt.CustomButton.Image = null;
            this.usernametxt.CustomButton.Location = new System.Drawing.Point(306, 1);
            this.usernametxt.CustomButton.Name = "";
            this.usernametxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.usernametxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.usernametxt.CustomButton.TabIndex = 1;
            this.usernametxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.usernametxt.CustomButton.UseSelectable = true;
            this.usernametxt.CustomButton.Visible = false;
            this.usernametxt.DisplayIcon = true;
            this.usernametxt.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.usernametxt.Icon = ((System.Drawing.Image)(resources.GetObject("usernametxt.Icon")));
            this.usernametxt.IconRight = true;
            this.usernametxt.Lines = new string[0];
            this.usernametxt.Location = new System.Drawing.Point(23, 162);
            this.usernametxt.MaxLength = 32767;
            this.usernametxt.Name = "usernametxt";
            this.usernametxt.PasswordChar = '\0';
            this.usernametxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.usernametxt.SelectedText = "";
            this.usernametxt.SelectionLength = 0;
            this.usernametxt.SelectionStart = 0;
            this.usernametxt.ShortcutsEnabled = true;
            this.usernametxt.Size = new System.Drawing.Size(340, 35);
            this.usernametxt.TabIndex = 1;
            this.usernametxt.UseSelectable = true;
            this.usernametxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.usernametxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // passwordtxt
            // 
            // 
            // 
            // 
            this.passwordtxt.CustomButton.Image = null;
            this.passwordtxt.CustomButton.Location = new System.Drawing.Point(306, 1);
            this.passwordtxt.CustomButton.Name = "";
            this.passwordtxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.passwordtxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passwordtxt.CustomButton.TabIndex = 1;
            this.passwordtxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passwordtxt.CustomButton.UseSelectable = true;
            this.passwordtxt.CustomButton.Visible = false;
            this.passwordtxt.DisplayIcon = true;
            this.passwordtxt.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.passwordtxt.Icon = ((System.Drawing.Image)(resources.GetObject("passwordtxt.Icon")));
            this.passwordtxt.IconRight = true;
            this.passwordtxt.Lines = new string[0];
            this.passwordtxt.Location = new System.Drawing.Point(23, 228);
            this.passwordtxt.MaxLength = 32767;
            this.passwordtxt.Name = "passwordtxt";
            this.passwordtxt.PasswordChar = '*';
            this.passwordtxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordtxt.SelectedText = "";
            this.passwordtxt.SelectionLength = 0;
            this.passwordtxt.SelectionStart = 0;
            this.passwordtxt.ShortcutsEnabled = true;
            this.passwordtxt.Size = new System.Drawing.Size(340, 35);
            this.passwordtxt.TabIndex = 2;
            this.passwordtxt.UseSelectable = true;
            this.passwordtxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passwordtxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // loginbtn
            // 
            this.loginbtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.loginbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(166)))), ((int)(((byte)(209)))));
            this.loginbtn.FlatAppearance.BorderSize = 0;
            this.loginbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginbtn.ForeColor = System.Drawing.Color.White;
            this.loginbtn.Location = new System.Drawing.Point(236, 345);
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Size = new System.Drawing.Size(133, 44);
            this.loginbtn.TabIndex = 8;
            this.loginbtn.Text = "Login";
            this.loginbtn.UseVisualStyleBackColor = false;
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLabel1.Location = new System.Drawing.Point(23, 278);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(144, 19);
            this.metroLabel1.TabIndex = 9;
            this.metroLabel1.Text = "Forgot your password?";
            this.metroLabel1.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLabel2.Location = new System.Drawing.Point(23, 306);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(99, 19);
            this.metroLabel2.TabIndex = 10;
            this.metroLabel2.Text = "Create Account";
            this.metroLabel2.Click += new System.EventHandler(this.metroLabel2_Click);
            // 
            // rememberbox
            // 
            this.rememberbox.AutoSize = true;
            this.rememberbox.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.rememberbox.Location = new System.Drawing.Point(34, 354);
            this.rememberbox.Name = "rememberbox";
            this.rememberbox.Size = new System.Drawing.Size(196, 25);
            this.rememberbox.TabIndex = 11;
            this.rememberbox.Text = "Remember me(Soon)";
            this.rememberbox.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(83, 92);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(202, 25);
            this.metroLabel3.TabIndex = 12;
            this.metroLabel3.Text = "Welcome To CarryBuddy!";
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.error.ForeColor = System.Drawing.Color.Red;
            this.error.Location = new System.Drawing.Point(110, 127);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(0, 18);
            this.error.TabIndex = 13;
            this.error.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.error.SizeChanged += new System.EventHandler(this.error_SizeChanged);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 412);
            this.ControlBox = false;
            this.Controls.Add(this.error);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.rememberbox);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.loginbtn);
            this.Controls.Add(this.passwordtxt);
            this.Controls.Add(this.usernametxt);
            this.Controls.Add(this.metroPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Movable = false;
            this.Name = "login";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button minimisebtn;
        private MetroFramework.Controls.MetroTextBox usernametxt;
        private MetroFramework.Controls.MetroTextBox passwordtxt;
        private System.Windows.Forms.Button loginbtn;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroCheckBox rememberbox;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.Label error;
    }
}