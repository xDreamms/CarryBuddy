namespace CarryBuddy.View_Models
{
    partial class ScriptsControl
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
            this.ScriptLV = new MetroFramework.Controls.MetroListView();
            this.ScriptCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PathCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ScriptLV
            // 
            this.ScriptLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ScriptCol,
            this.PathCol});
            this.ScriptLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScriptLV.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ScriptLV.FullRowSelect = true;
            this.ScriptLV.Location = new System.Drawing.Point(0, 0);
            this.ScriptLV.Name = "ScriptLV";
            this.ScriptLV.OwnerDraw = true;
            this.ScriptLV.Size = new System.Drawing.Size(1144, 435);
            this.ScriptLV.TabIndex = 1;
            this.ScriptLV.UseCompatibleStateImageBehavior = false;
            this.ScriptLV.UseSelectable = true;
            this.ScriptLV.View = System.Windows.Forms.View.Details;
            this.ScriptLV.SelectedIndexChanged += new System.EventHandler(this.ScriptLV_SelectedIndexChanged);
            this.ScriptLV.Resize += new System.EventHandler(this.ScriptLV_Resize);
            // 
            // ScriptCol
            // 
            this.ScriptCol.Text = "Script";
            this.ScriptCol.Width = 500;
            // 
            // PathCol
            // 
            this.PathCol.Text = "Path";
            this.PathCol.Width = 600;
            // 
            // ScriptsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ScriptLV);
            this.Name = "ScriptsControl";
            this.Size = new System.Drawing.Size(1144, 435);
            this.ResumeLayout(false);

        }

        #endregion
        public MetroFramework.Controls.MetroListView ScriptLV;
        public System.Windows.Forms.ColumnHeader ScriptCol;
        private System.Windows.Forms.ColumnHeader PathCol;
    }
}
