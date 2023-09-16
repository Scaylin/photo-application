using System;
using System.Windows.Forms;

namespace Projet_S4
{
    public partial class AppliquerFiltre : Form
    {
        public AppliquerFiltre()
        {
            InitializeComponent();
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

        private MyImage ChoixFiltre(MyImage image)
        {
            switch (CbFiltre.SelectedIndex)
            {
                case 0:
                    image.FlouterImage();

                    break;
                case 1:
                    image.FlouterImage();
                    image.FlouterImage();
                    image.FlouterImage();
                    image.FlouterImage();
                    image.FlouterImage();


                    break;
                case 2:
                    image.ContourImage();

                    break;
                case 3:
                    image.ContourImage2();

                    break;
                case 4:
                    image.Repoussage();

                    break;
                default:
                    image.FlouterImage();

                    break;
            }
            return image;
        }

        private void BtnGenerer_Click(object sender, EventArgs e)
        {
            while (TxtBoxNom.TextLength == 0)
            {
                return;
            }
            MyImage image = ChoixImage();
            ChoixFiltre(image);
            image.From_Image_To_File(TxtBoxNom.Text);
        }

        private void CbChoixImage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
