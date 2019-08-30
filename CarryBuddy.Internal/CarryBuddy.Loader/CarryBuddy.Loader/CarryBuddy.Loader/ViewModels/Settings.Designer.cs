namespace CarryBuddy.Loader.ViewModels
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.TopMenuBar = new System.Windows.Forms.Panel();
            this.CarryBuddyText = new System.Windows.Forms.Label();
            this.MinimiseButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.UserDetailsCheckbox = new MetroFramework.Controls.MetroCheckBox();
            this.SplashCheckbox = new MetroFramework.Controls.MetroCheckBox();
            this.TopMenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopMenuBar
            // 
            this.TopMenuBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TopMenuBar.Controls.Add(this.CarryBuddyText);
            this.TopMenuBar.Controls.Add(this.MinimiseButton);
            this.TopMenuBar.Controls.Add(this.CloseButton);
            this.TopMenuBar.Location = new System.Drawing.Point(0, 0);
            this.TopMenuBar.Name = "TopMenuBar";
            this.TopMenuBar.Size = new System.Drawing.Size(498, 46);
            this.TopMenuBar.TabIndex = 2;
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
            this.MinimiseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MinimiseButton.BackgroundImage")));
            this.MinimiseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MinimiseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimiseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimiseButton.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.MinimiseButton.Location = new System.Drawing.Point(375, 0);
            this.MinimiseButton.Name = "MinimiseButton";
            this.MinimiseButton.Size = new System.Drawing.Size(57, 40);
            this.MinimiseButton.TabIndex = 2;
            this.MinimiseButton.UseVisualStyleBackColor = true;
            this.MinimiseButton.Click += new System.EventHandler(this.MinimiseButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseButton.BackgroundImage")));
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.CloseButton.Location = new System.Drawing.Point(438, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(57, 43);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // UserDetailsCheckbox
            // 
            this.UserDetailsCheckbox.AutoSize = true;
            this.UserDetailsCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UserDetailsCheckbox.Checked = true;
            this.UserDetailsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UserDetailsCheckbox.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.UserDetailsCheckbox.Location = new System.Drawing.Point(157, 100);
            this.UserDetailsCheckbox.Name = "UserDetailsCheckbox";
            this.UserDetailsCheckbox.Size = new System.Drawing.Size(168, 19);
            this.UserDetailsCheckbox.TabIndex = 3;
            this.UserDetailsCheckbox.Text = "Remember User Details";
            this.UserDetailsCheckbox.UseCustomBackColor = true;
            this.UserDetailsCheckbox.UseCustomForeColor = true;
            this.UserDetailsCheckbox.UseSelectable = true;
            this.UserDetailsCheckbox.CheckedChanged += new System.EventHandler(this.UserDetailsCheckbox_CheckedChanged);
            // 
            // SplashCheckbox
            // 
            this.SplashCheckbox.AutoSize = true;
            this.SplashCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SplashCheckbox.Checked = true;
            this.SplashCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SplashCheckbox.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.SplashCheckbox.Location = new System.Drawing.Point(157, 136);
            this.SplashCheckbox.Name = "SplashCheckbox";
            this.SplashCheckbox.Size = new System.Drawing.Size(179, 19);
            this.SplashCheckbox.TabIndex = 4;
            this.SplashCheckbox.Text = "Display Splash At Startup";
            this.SplashCheckbox.UseCustomBackColor = true;
            this.SplashCheckbox.UseCustomForeColor = true;
            this.SplashCheckbox.UseSelectable = true;
            this.SplashCheckbox.CheckedChanged += new System.EventHandler(this.SplashCheckbox_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 371);
            this.Controls.Add(this.SplashCheckbox);
            this.Controls.Add(this.UserDetailsCheckbox);
            this.Controls.Add(this.TopMenuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.TopMenuBar.ResumeLayout(false);
            this.TopMenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TopMenuBar;
        private System.Windows.Forms.Label CarryBuddyText;
        private System.Windows.Forms.Button MinimiseButton;
        private System.Windows.Forms.Button CloseButton;
        private MetroFramework.Controls.MetroCheckBox UserDetailsCheckbox;
        private MetroFramework.Controls.MetroCheckBox SplashCheckbox;
    }
}