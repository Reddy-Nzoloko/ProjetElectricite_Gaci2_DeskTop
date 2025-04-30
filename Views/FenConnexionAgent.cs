using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Views
{
    public partial class FenConnexionAgent : Form
    {
        public FenConnexionAgent()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            FenPrincipale fene = new FenPrincipale();
            fene.Show();
        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            Form1 fom = new Form1();
            fom.Show();
        }
    }
}
