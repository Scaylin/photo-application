using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_S4
{
    public partial class AppliMyImage : Form
    {
        public AppliMyImage()
        {
            InitializeComponent();
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnModifierUneImage_Click(object sender, EventArgs e)
        {
            ModifierImage appli = new ModifierImage();
            appli.Location = Location;
            appli.Height = 600;
            appli.Width = 800;
            appli.ShowDialog();
        }

        private void BtnHistogramme_Click(object sender, EventArgs e)
        {
            Histogramme appli = new Histogramme();
            appli.Location = Location;
            appli.Height = 600;
            appli.Width = 800;
            appli.ShowDialog();

        }

        private void BtnFractales_Click(object sender, EventArgs e)
        {
            Fractales appli = new Fractales();
            appli.Location = Location;
            appli.Height = 600;
            appli.Width = 800;
            appli.ShowDialog();

            
        }

        private void BtnQRCode_Click(object sender, EventArgs e)
        {
            QR appli = new QR();
            appli.Location = Location;
            appli.Height = 600;
            appli.Width = 800;
            appli.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnFiltre_Click(object sender, EventArgs e)
        {
            AppliquerFiltre appli = new AppliquerFiltre();
            appli.Location = Location;
            appli.Height = 600;
            appli.Width = 800;
            appli.ShowDialog();
        }

        private void BtnStegano_Click(object sender, EventArgs e)
        {
            Steganographie appli = new Steganographie();
            appli.Location = Location;
            appli.Height = 600;
            appli.Width = 800;
            appli.ShowDialog();
        }

        private void btnInnovation_Click(object sender, EventArgs e)
        {
            Innovation appli = new Innovation();
            appli.Location = Location;
            appli.Height = 600;
            appli.Width = 800;
            appli.ShowDialog();
        }
    }
}
