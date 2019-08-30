namespace CarryBuddy.Loader.ViewModels.Embeds
{
    partial class ScriptView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainText = new System.Windows.Forms.Label();
            this.ScriptListView = new MetroFramework.Controls.MetroListView();
            this.ScriptName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // MainText
            // 
            this.MainText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MainText.AutoSize = true;
            this.MainText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainText.ForeColor = System.Drawing.Color.Black;
            this.MainText.Location = new System.Drawing.Point(227, 34);
            this.MainText.Name = "MainText";
            this.MainText.Size = new System.Drawing.Size(98, 31);
            this.MainText.TabIndex = 1;
            this.MainText.Text = "Scripts";
            // 
            // ScriptListView
            // 
            this.ScriptListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ScriptListView.CheckBoxes = true;
            this.ScriptListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ScriptName,
            this.Version});
            this.ScriptListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ScriptListView.FullRowSelect = true;
            this.ScriptListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ScriptListView.Location = new System.Drawing.Point(3, 78);
            this.ScriptListView.Name = "ScriptListView";
            this.ScriptListView.OwnerDraw = true;
            this.ScriptListView.Size = new System.Drawing.Size(564, 286);
            this.ScriptListView.TabIndex = 2;
            this.ScriptListView.UseCompatibleStateImageBehavior = false;
            this.ScriptListView.UseSelectable = true;
            this.ScriptListView.View = System.Windows.Forms.View.Details;
            this.ScriptListView.Resize += new System.EventHandler(this.ScriptListView_Resize);
            // 
            // ScriptName
            // 
            this.ScriptName.Text = "Script";
            this.ScriptName.Width = 270;
            // 
            // Version
            // 
            this.Version.Text = "Version";
            this.Version.Width = 293;
            // 
            // ScriptView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ScriptListView);
            this.Controls.Add(this.MainText);
            this.Name = "ScriptView";
            this.Size = new System.Drawing.Size(570, 367);
            this.Load += new System.EventHandler(this.ScriptView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MainText;
        private MetroFramework.Controls.MetroListView ScriptListView;
        private System.Windows.Forms.ColumnHeader ScriptName;
        public System.Windows.Forms.ColumnHeader Version;
    }
}
