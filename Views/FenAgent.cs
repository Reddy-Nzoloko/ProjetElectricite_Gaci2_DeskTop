using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Views
{
    public partial class FenAgent : Form
    {
        public FenAgent()
        {
            InitializeComponent();
        }

        private void FenAgent_Load(object sender, EventArgs e)
        {
            
        }
        public async void save()
        {
            Dictionary<string, string> Champs = new Dictionary<string, string>
            {
                {"nomComplet",inpNomComplet.Text},
                {"nomUtilisateur",inpNomUtilisateur.Text},
                {"passwords",inpMotdepass.Text},
            };

            Controleur.ControleurUser Controler = new Controleur.ControleurUser(Champs);

            bool success= await Controler.Insert();
            if (success) {
                MessageBox.Show(Controler.LastMessage);            
            }
            else
            {
                MessageBox.Show(Controler.LastMessage);
            }
                
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            save();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
