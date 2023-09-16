using System;
using System.Windows.Forms;

namespace Projet_S4
{
    public partial class ModifierImage : Form
    {
        public ModifierImage()
        {
            InitializeComponent();
        }

        private void BtnGenerer_Click(object sender, EventArgs e)
        {
            while (TxtBoxNom.TextLength == 0 ||textBox1.TextLength == 0)
            {

            }
            MyImage image = ChoixImage();
            ChoixAction(image);
        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            Close();
        }

        private MyImage ChoixImage()
        {
            MyImage image;
            MyImage copie;
            switch (CbChoixImage.SelectedIndex)
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

        private void ChoixAction(MyImage image)
        {
            switch (CbChoixModif.SelectedIndex)
            {
                case 0:
                    image.NoirEtBlanc();
                    break;
                case 1:
                    image.NuanceDeGris();
                    break;
                case 2:
                    image.Tourner();
                    break;
                case 3:
                    image.Tourner();
                    image.Tourner();
                    break;
                case 4:
                    image.Tourner();
                    image.Tourner();
                    image.Tourner();
                    break;
                case 5:
                    image.Miroir();
                    break;
                case 6:
                    image.MiroirVertical();
                    break;
                case 7:
                    image.Negatif();
                    break;
                case 8:
                    double ratio = Convert.ToDouble(textBox1.Text);
                    
                    image.AgrandirImage(ratio);
                    break;
                default:
                    image.NoirEtBlanc();
                    break;

            }
            image.From_Image_To_File(TxtBoxNom.Text);

        }
    }
}
