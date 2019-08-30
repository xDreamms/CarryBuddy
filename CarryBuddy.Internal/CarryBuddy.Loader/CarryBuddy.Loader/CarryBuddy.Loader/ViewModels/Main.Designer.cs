namespace CarryBuddy.Loader.ViewModels
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.TopMenuBar = new System.Windows.Forms.Panel();
            this.CarryBuddyText = new System.Windows.Forms.Label();
            this.MinimiseButton = new System.Windows.Forms.Button();
            this.MaximiseButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.BottomFooter = new System.Windows.Forms.Panel();
            this.InjectButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.UserPFPBox = new System.Windows.Forms.PictureBox();
            this.UsernameText = new System.Windows.Forms.Label();
            this.VersionText = new System.Windows.Forms.Label();
            this.newsView1 = new CarryBuddy.Loader.ViewModels.Embeds.NewsView();
            this.scriptView1 = new CarryBuddy.Loader.ViewModels.Embeds.ScriptView();
            this.TopMenuBar.SuspendLayout();
            this.BottomFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserPFPBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TopMenuBar
            // 
            this.TopMenuBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TopMenuBar.Controls.Add(this.CarryBuddyText);
            this.TopMenuBar.Controls.Add(this.MinimiseButton);
            this.TopMenuBar.Controls.Add(this.MaximiseButton);
            this.TopMenuBar.Controls.Add(this.CloseButton);
            this.TopMenuBar.Location = new System.Drawing.Point(-1, 0);
            this.TopMenuBar.Name = "TopMenuBar";
            this.TopMenuBar.Size = new System.Drawing.Size(905, 43);
            this.TopMenuBar.TabIndex = 0;
            this.TopMenuBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopMenuBar_MouseDown);
            // 
            // CarryBuddyText
            // 
            this.CarryBuddyText.AutoSize = true;
            this.CarryBuddyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CarryBuddyText.Location = new System.Drawing.Point(24, 9);
            this.CarryBuddyText.Name = "CarryBuddyText";
            this.CarryBuddyText.Size = new System.Drawing.Size(108, 24);
            this.CarryBuddyText.TabIndex = 3;
            this.CarryBuddyText.Text = "CarryBuddy";
            // 
            // MinimiseButton
            // 
            this.MinimiseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimiseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimiseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimiseButton.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.MinimiseButton.Image = ((System.Drawing.Image)(resources.GetObject("MinimiseButton.Image")));
            this.MinimiseButton.Location = new System.Drawing.Point(659, 0);
            this.MinimiseButton.Name = "MinimiseButton";
            this.MinimiseButton.Size = new System.Drawing.Size(77, 40);
            this.MinimiseButton.TabIndex = 2;
            this.MinimiseButton.UseVisualStyleBackColor = true;
            this.MinimiseButton.Click += new System.EventHandler(this.MinimiseButton_Click);
            // 
            // MaximiseButton
            // 
            this.MaximiseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaximiseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaximiseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximiseButton.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.MaximiseButton.Image = ((System.Drawing.Image)(resources.GetObject("MaximiseButton.Image")));
            this.MaximiseButton.Location = new System.Drawing.Point(742, 0);
            this.MaximiseButton.Name = "MaximiseButton";
            this.MaximiseButton.Size = new System.Drawing.Size(77, 43);
            this.MaximiseButton.TabIndex = 1;
            this.MaximiseButton.UseVisualStyleBackColor = true;
            this.MaximiseButton.Click += new System.EventHandler(this.MaximiseButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseButton.BackgroundImage")));
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.CloseButton.Location = new System.Drawing.Point(825, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(77, 43);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // BottomFooter
            // 
            this.BottomFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BottomFooter.Controls.Add(this.InjectButton);
            this.BottomFooter.Controls.Add(this.SettingsButton);
            this.BottomFooter.Controls.Add(this.UserPFPBox);
            this.BottomFooter.Controls.Add(this.UsernameText);
            this.BottomFooter.Controls.Add(this.VersionText);
            this.BottomFooter.Location = new System.Drawing.Point(-1, 414);
            this.BottomFooter.Name = "BottomFooter";
            this.BottomFooter.Size = new System.Drawing.Size(905, 43);
            this.BottomFooter.TabIndex = 3;
            // 
            // InjectButton
            // 
            this.InjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.InjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InjectButton.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.InjectButton.Location = new System.Drawing.Point(508, 0);
            this.InjectButton.Name = "InjectButton";
            this.InjectButton.Size = new System.Drawing.Size(99, 43);
            this.InjectButton.TabIndex = 4;
            this.InjectButton.Text = "Inject";
            this.InjectButton.UseVisualStyleBackColor = true;
            this.InjectButton.Click += new System.EventHandler(this.InjectButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButton.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.SettingsButton.Image = ((System.Drawing.Image)(resources.GetObject("SettingsButton.Image")));
            this.SettingsButton.Location = new System.Drawing.Point(627, 0);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(77, 43);
            this.SettingsButton.TabIndex = 4;
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // UserPFPBox
            // 
            this.UserPFPBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UserPFPBox.Location = new System.Drawing.Point(13, 3);
            this.UserPFPBox.Name = "UserPFPBox";
            this.UserPFPBox.Size = new System.Drawing.Size(47, 37);
            this.UserPFPBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserPFPBox.TabIndex = 2;
            this.UserPFPBox.TabStop = false;
            // 
            // UsernameText
            // 
            this.UsernameText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UsernameText.AutoSize = true;
            this.UsernameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameText.Location = new System.Drawing.Point(79, 12);
            this.UsernameText.Name = "UsernameText";
            this.UsernameText.Size = new System.Drawing.Size(97, 24);
            this.UsernameText.TabIndex = 1;
            this.UsernameText.Text = "Username";
            // 
            // VersionText
            // 
            this.VersionText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.VersionText.AutoSize = true;
            this.VersionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionText.Location = new System.Drawing.Point(738, 12);
            this.VersionText.Name = "VersionText";
            this.VersionText.Size = new System.Drawing.Size(110, 24);
            this.VersionText.TabIndex = 0;
            this.VersionText.Text = "Version Info";
            // 
            // newsView1
            // 
            this.newsView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newsView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(24)))), ((int)(((byte)(31)))));
            this.newsView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(24)))), ((int)(((byte)(31)))));
            this.newsView1.Location = new System.Drawing.Point(626, 78);
            this.newsView1.Name = "newsView1";
            this.newsView1.Size = new System.Drawing.Size(265, 290);
            this.newsView1.TabIndex = 2;
            // 
            // scriptView1
            // 
            this.scriptView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(24)))), ((int)(((byte)(31)))));
            this.scriptView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(24)))), ((int)(((byte)(31)))));
            this.scriptView1.Location = new System.Drawing.Point(27, 78);
            this.scriptView1.Name = "scriptView1";
            this.scriptView1.Size = new System.Drawing.Size(570, 290);
            this.scriptView1.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 457);
            this.Controls.Add(this.BottomFooter);
            this.Controls.Add(this.newsView1);
            this.Controls.Add(this.scriptView1);
            this.Controls.Add(this.TopMenuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.TopMenuBar.ResumeLayout(false);
            this.TopMenuBar.PerformLayout();
            this.BottomFooter.ResumeLayout(false);
            this.BottomFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserPFPBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopMenuBar;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button MaximiseButton;
        private System.Windows.Forms.Button MinimiseButton;
        private Embeds.ScriptView scriptView1;
        private Embeds.NewsView newsView1;
        private System.Windows.Forms.Panel BottomFooter;
        private System.Windows.Forms.Label VersionText;
        private System.Windows.Forms.Label UsernameText;
        private System.Windows.Forms.PictureBox UserPFPBox;
        private System.Windows.Forms.Label CarryBuddyText;
        public System.Windows.Forms.Button SettingsButton;
        public System.Windows.Forms.Button InjectButton;
    }
}