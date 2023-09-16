using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_S4
{
    public partial class QR : Form
    {
        public QR()
        {
            InitializeComponent();
        }

        private void textBoxSaisie_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnGenerer_Click(object sender, EventArgs e)
        {
            while(TextBoxNom.TextLength == 0 || TextBoxSaisie.TextLength == 0)
            {
                return;
            }
            QRCode sr = new QRCode(TextBoxSaisie.Text, TextBoxNom.Text);
            //Process.Start(TextBoxNom.Text + ".bmp");
        }

        

        private void TextBoxSaisie_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
