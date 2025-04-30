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
    public partial class FenPrincipale : Form
    {
        public FenPrincipale()
        {
            InitializeComponent();
        }
        // chargement des formulaire sinlge page 
        
        Form formulaireEnCours;
        void OpenForms(Form formulairePere, object ecouteur)
        {

            if (formulaireEnCours != null)
            {
                formulaireEnCours.Close();
            }
            formulaireEnCours = formulairePere;
            formulairePere.TopLevel = false;
            formulairePere.FormBorderStyle = FormBorderStyle.None;
            formulairePere.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(formulairePere);
            this.panel1.Tag = formulairePere;
            formulairePere.BringToFront();
            formulairePere.Show();

        }

        private void FenPrincipale_Load(object sender, EventArgs e)
        {

        }

        // appel de la fenetre dans le single page comme menu
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            OpenForms(new FenAgent(), sender);
        }
    }
}
