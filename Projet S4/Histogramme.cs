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
    public partial class Histogramme : Form
    {
        public Histogramme()
        {
            InitializeComponent();
        }

        private void BtnGenerer_Click(object sender, EventArgs e)
        {
            
            MyImage image;
            switch(ComboBoxChoix.SelectedIndex)
            {
                case 0:
                    image = new MyImage("Coco");
                    image.HistogrammeRGB();
                    break;
                case 1:
                    image = new MyImage("Lac");
                    image.HistogrammeRGB();
                    break;
                case 2:
                    image = new MyImage("Lena");
                    image.HistogrammeRGB();
                    break;
                case 3:
                    image = new MyImage("Image Test 1");
                    image.HistogrammeRGB();
                    break;
                case 4:
                    image = new MyImage("Image Test 2");
                    image.HistogrammeRGB();
                    break;
                case 5:
                    image = new MyImage("Image Test 3");
                    image.HistogrammeRGB();
                    break;
                default:
                    image = new MyImage("Coco");
                    image.HistogrammeRGB();
                    break;

            }
            
        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ComboBoxChoix_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
