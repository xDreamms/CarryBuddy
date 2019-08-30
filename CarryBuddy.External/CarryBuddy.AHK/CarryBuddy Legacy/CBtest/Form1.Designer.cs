namespace CBtest
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
            this.scrcount = new MetroFramework.Controls.MetroLabel();
            this.Home = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.labelact = new MetroFramework.Controls.MetroLabel();
            this.actck = new MetroFramework.Controls.MetroCheckBox();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.sclabel = new MetroFramework.Controls.MetroLabel();
            this.Home.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scrcount
            // 
            this.scrcount.AutoSize = true;
            this.scrcount.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.scrcount.Location = new System.Drawing.Point(299, 79);
            this.scrcount.Name = "scrcount";
            this.scrcount.Size = new System.Drawing.Size(116, 25);
            this.scrcount.TabIndex = 2;
            this.scrcount.Text = "1 Script Ready";
            // 
            // Home
            // 
            this.Home.Controls.Add(this.metroTabPage1);
            this.Home.Controls.Add(this.metroTabPage2);
            this.Home.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.Home.Location = new System.Drawing.Point(23, 77);
            this.Home.Name = "Home";
            this.Home.SelectedIndex = 0;
            this.Home.Size = new System.Drawing.Size(754, 350);
            this.Home.TabIndex = 4;
            this.Home.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.sclabel);
            this.metroTabPage1.Controls.Add(this.labelact);
            this.metroTabPage1.Controls.Add(this.actck);
            this.metroTabPage1.Controls.Add(this.scrcount);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 44);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(746, 302);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Home";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // labelact
            // 
            this.labelact.AutoSize = true;
            this.labelact.Location = new System.Drawing.Point(318, 283);
            this.labelact.Name = "labelact";
            this.labelact.Size = new System.Drawing.Size(0, 0);
            this.labelact.TabIndex = 5;
            // 
            // actck
            // 
            this.actck.AutoSize = true;
            this.actck.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.actck.Location = new System.Drawing.Point(299, 236);
            this.actck.Name = "actck";
            this.actck.Size = new System.Drawing.Size(91, 25);
            this.actck.TabIndex = 3;
            this.actck.Text = "Activate";
            this.actck.UseSelectable = true;
            this.actck.CheckedChanged += new System.EventHandler(this.metroCheckBox2_CheckedChanged);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 44);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(746, 302);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "News";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // sclabel
            // 
            this.sclabel.AutoSize = true;
            this.sclabel.Location = new System.Drawing.Point(335, 117);
            this.sclabel.Name = "sclabel";
            this.sclabel.Size = new System.Drawing.Size(0, 0);
            this.sclabel.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Home);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Text = "CarryBuddy";
            this.Home.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroLabel scrcount;
        private MetroFramework.Controls.MetroTabControl Home;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroCheckBox actck;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroLabel labelact;
        private MetroFramework.Controls.MetroLabel sclabel;
    }
}

