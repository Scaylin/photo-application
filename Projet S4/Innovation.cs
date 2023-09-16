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
    public partial class Innovation : Form
    {
        public Innovation()
        {
            InitializeComponent();
        }

        private void btnGenerer_Click(object sender, EventArgs e)
        {
            Bruit aa = new Bruit();
            Random rand = new Random();
            MyImage map = new MyImage(500, 500, textBox1.Text, new Pixel(0, 0, 0));
            double[,] mat = new double[map.Hauteur, map.Largeur];
            double max = 0;
            double min = 0;
            int a = rand.Next(-2, 2);
            int b = rand.Next(-2, 2);
            int c = rand.Next(-2, 2);
            for (double i = 0; i < map.Hauteur; i++)
            {
                for (double j = 0; j < map.Largeur; j++)
                {


                    double height = aa.GenererBruit(i / 10, j / 10, a, b, c);

                    if (max <= height)
                    {
                        max = height;
                    }
                    else if (min >= height)
                    {
                        min = height;
                    }
                    mat[(int)i, (int)j] = height;
                }
            }
            double vraiMax = max + min;
            for (double i = 0; i < map.Hauteur; i++)
            {
                for (double j = 0; j < map.Largeur; j++)
                {
                    double vraiHeight = mat[(int)i, (int)j] / vraiMax;
                    Pixel pix = aa.ApplicationCouleur(vraiHeight);
                    map.Matrice[(int)i, (int)j] = pix;

                }
            }
            map.From_Scratch_Image_To_File();
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
