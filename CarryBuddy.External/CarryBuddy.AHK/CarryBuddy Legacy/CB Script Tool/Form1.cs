using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CB_Script_Tool
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (scname.Text.Length == 0)
            {
                MessageBox.Show("Please Enter the script name.");
                return;
            }
            if (richTextBox1.Text.Length == 0)
            {
                MessageBox.Show("Please write a valid script in the box.");
                return;
            }



            FolderBrowserDialog fld = new FolderBrowserDialog();
            if (fld.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(fld.SelectedPath + "\\" + scname.Text + ".cbaddon", richTextBox1.Text);
                MetroFramework.MetroMessageBox.Show(this, "Saved to " + fld.SelectedPath + "\\" + scname.Text + ".txt", "Saved Script", MessageBoxButtons.OK, MessageBoxIcon.Information);
               


            }
        }

        private void Openscbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "CarryBuddy Script (*.cbaddon)|*.cbaddon";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((openFileDialog1.OpenFile()) != null)
                    {

                        string fpath = openFileDialog1.FileName;
                        string fname = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);


                        string lines = System.IO.File.ReadAllText(fpath);

                        // Display the file contents by using a foreach loop.
                        scname.Text = fname;

                        richTextBox1.Text = lines;
                        this.CheckKeyword("UseQ()", Color.Green, 0);
                        this.CheckKeyword("UseW()", Color.Green, 0);
                        this.CheckKeyword("UseE()", Color.Green, 0);
                        this.CheckKeyword("UseR()", Color.Green, 0);
                        this.CheckKeyword("UseItem", Color.Green, 0);
                        this.CheckKeyword("MoveMouseToEnemy()", Color.Green, 0);
                        this.CheckKeyword("AttackEnemy()", Color.Purple, 0);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.CheckKeyword("UseQ()", Color.Green, 0);
            this.CheckKeyword("UseW()", Color.Green, 0);
            this.CheckKeyword("UseE()", Color.Green, 0);
            this.CheckKeyword("UseR()", Color.Green, 0);
            this.CheckKeyword("UseItem", Color.Green, 0);
            this.CheckKeyword("MoveMouseToEnemy()", Color.Green, 0);
            this.CheckKeyword("AttackEnemy()", Color.Purple, 0);
        }


        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.richTextBox1.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.richTextBox1.SelectionStart;

                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox1.Select((index + startIndex), word.Length);
                    this.richTextBox1.SelectionColor = color;
                    this.richTextBox1.Select(selectStart, 0);
                    this.richTextBox1.SelectionColor = Color.Black;
                }
            }
        }
    }
}
