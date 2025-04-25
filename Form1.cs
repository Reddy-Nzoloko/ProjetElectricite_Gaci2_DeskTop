using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;
using WindowsFormsApp1.Views;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            Apps.Query.ip_ = InpAdresseIp.Text;
            Apps.Query.port_ = InpPort.Text;
            Apps.Query.DataBase_ = inpNomBdd.Text;
            Apps.Query.passWord_ = inpMotdepassServeur.Text;
            Apps.Query.UserName_=inpNomUtilsateur.Text;

            Apps.Query.TestConnection();
        }

        // enregistrement des information dans l'application
        private void BtnConnexion_Click(object sender, EventArgs e)
        {
            Settings.Default.ip = InpAdresseIp.Text;
            Settings.Default.port = InpPort.Text;
            Settings.Default.DataBase = inpNomBdd.Text;
            Settings.Default.UserName=inpNomUtilsateur.Text;
            Settings.Default.Password = inpMotdepassServeur.Text;

            Settings.Default.Save();
            MessageBox.Show("Successful l'application va se redemarer");
            Application.Restart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InpAdresseIp.Text = Settings.Default.ip;
            inpNomBdd.Text = Settings.Default.DataBase;
            inpNomUtilsateur.Text = Settings.Default.UserName;
            inpMotdepassServeur.Text = Settings.Default.Password;
            InpPort.Text = Settings.Default.port;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            FenAgent fenA = new FenAgent();
            fenA.Show();
            this.Hide();
        }
    }
}
