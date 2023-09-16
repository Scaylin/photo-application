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
    public partial class Steganographie : Form
    {
        public Steganographie()
        {
            InitializeComponent();
        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnGenerer_Click(object sender, EventArgs e)
        {
            MyImage image1 = choixImage(comboBox1);
            MyImage image2 = choixImage(comboBox2);
            if(image1.Largeur*image1.Hauteur< image2.Largeur * image2.Hauteur)
            {
                MyImage decrypte = MyImage.Steganographie(image2, image1);
                MyImage.DecrypteStegano(decrypte);

            }
            else
            {
                MyImage decrypte = MyImage.Steganographie(image1, image2);
                MyImage.DecrypteStegano(decrypte);
            }
        }

        private MyImage choixImage(ComboBox comboBox)
        {
            MyImage image;
            MyImage copie;

            switch (comboBox.SelectedIndex)
            {
                case 0:
                    image = new MyImage("Coco");
                    copie = new MyImage(image);

                    break;
                case 1:
                    image = new MyImage("Lac");
                    copie = new MyImage(image);

                    break;
                case 2:
                    image = new MyImage("Lena");
                    copie = new MyImage(image);

                    break;
                case 3:
                    image = new MyImage("Image Test 1");
                    copie = new MyImage(image);

                    break;
                case 4:
                    image = new MyImage("Image Test 2");
                    copie = new MyImage(image);

                    break;
                case 5:
                    image = new MyImage("Image Test 3");
                    copie = new MyImage(image);

                    break;
                default:
                    image = new MyImage("Coco");
                    copie = new MyImage(image);

                    break;
            }
            return copie;
        }
    }
}
