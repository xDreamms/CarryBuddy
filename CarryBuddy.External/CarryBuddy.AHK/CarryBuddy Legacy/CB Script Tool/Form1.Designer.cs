namespace CB_Script_Tool
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Savebtn = new MetroFramework.Controls.MetroButton();
            this.scname = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.Openscbtn = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(23, 109);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(754, 321);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // Savebtn
            // 
            this.Savebtn.Location = new System.Drawing.Point(416, 22);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(80, 32);
            this.Savebtn.TabIndex = 1;
            this.Savebtn.Text = "Save";
            this.Savebtn.UseSelectable = true;
            this.Savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // scname
            // 
            // 
            // 
            // 
            this.scname.CustomButton.Image = null;
            this.scname.CustomButton.Location = new System.Drawing.Point(265, 1);
            this.scname.CustomButton.Name = "";
            this.scname.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.scname.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.scname.CustomButton.TabIndex = 1;
            this.scname.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.scname.CustomButton.UseSelectable = true;
            this.scname.CustomButton.Visible = false;
            this.scname.Lines = new string[0];
            this.scname.Location = new System.Drawing.Point(112, 80);
            this.scname.MaxLength = 32767;
            this.scname.Name = "scname";
            this.scname.PasswordChar = '\0';
            this.scname.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.scname.SelectedText = "";
            this.scname.SelectionLength = 0;
            this.scname.SelectionStart = 0;
            this.scname.ShortcutsEnabled = true;
            this.scname.Size = new System.Drawing.Size(287, 23);
            this.scname.TabIndex = 2;
            this.scname.UseSelectable = true;
            this.scname.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.scname.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 80);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(82, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Script name:";
            // 
            // Openscbtn
            // 
            this.Openscbtn.Location = new System.Drawing.Point(319, 22);
            this.Openscbtn.Name = "Openscbtn";
            this.Openscbtn.Size = new System.Drawing.Size(80, 32);
            this.Openscbtn.TabIndex = 4;
            this.Openscbtn.Text = "Open Script";
            this.Openscbtn.UseSelectable = true;
            this.Openscbtn.Click += new System.EventHandler(this.Openscbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Openscbtn);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.scname);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.richTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Text = "CarryBuddy for Developers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private MetroFramework.Controls.MetroButton Savebtn;
        private MetroFramework.Controls.MetroTextBox scname;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton Openscbtn;
    }
}

