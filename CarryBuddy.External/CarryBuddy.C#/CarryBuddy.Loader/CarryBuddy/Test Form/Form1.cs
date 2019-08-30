using System;
using System.Collections;
using System.Windows.Forms;

namespace CarryBuddy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static void ShowArrayList(ArrayList arrayList)
        {
            string arrayText = "";

            foreach (object obj in arrayList)
            {
                arrayText += obj + "\n";
            }

            MessageBox.Show(arrayText);
        }

        private void YiCombo()
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
