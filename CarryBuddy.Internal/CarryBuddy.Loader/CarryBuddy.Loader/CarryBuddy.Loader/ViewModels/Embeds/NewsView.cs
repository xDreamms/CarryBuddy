using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarryBuddy.Loader.ViewModels.Embeds
{
    public partial class NewsView : UserControl
    {
        public NewsView()
        {
            InitializeComponent();
        }

        private void NewsView_Load(object sender, EventArgs e)
        {
            InitialiseDesign();
        }

        public void InitialiseDesign()
        {
            this.BackColor = Color.FromArgb(18, 24, 31);
        }
    }
}
