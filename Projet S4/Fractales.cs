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
    public partial class Fractales : Form
    {
        public Fractales()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while(textBox1.TextLength == 0)
            {
                return;
            }
            MyImage image;          
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    image = new MyImage(500, 500,textBox1.Text, new Pixel(0, 0, 0));
                    break;
                case 1:
                    image = new MyImage(1000, 1000, textBox1.Text, new Pixel(0, 0, 0));
                    break;
                case 2:
                    image = new MyImage(2000, 2000, textBox1.Text, new Pixel(0, 0, 0));
                    break;
                case 3:
                    image = new MyImage(4000, 4000, textBox1.Text, new Pixel(0, 0, 0));
                    break;
                case 4:
                    image = new MyImage(8000, 8000, textBox1.Text, new Pixel(0, 0, 0));
                    break;
                default:
                    image = new MyImage(2000, 2000, textBox1.Text, new Pixel(0, 0, 0));
                    break;
            }
            ChoixFractale(image, textBox1.Text);
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void LabelDonnerNom_Click(object sender, EventArgs e)
        {

        }

        private void ChoixFractale(MyImage image, string nom)
        {
            Complexe nombre;
            switch(CBTypeFractale.SelectedIndex)
            {
                case 0:
                    image.Mandelbrot(nom, 2, 25);
                    break;
                case 1:
                    nombre = new Complexe(-0.63f , 0.67f);
                    image.Julia(nom, 2, 25, nombre);
                    break;
                case 2:
                    nombre = new Complexe(0.76f, 0.12f);
                    image.Julia(nom, 2, 25, nombre);
                    break;
                case 3:
                    nombre = new Complexe(-0.6f, 0.6f);
                    image.Julia(nom, 2, 25, nombre);
                    break;
                case 4:
                    nombre = new Complexe(-1, 0);
                    image.Julia(nom, 2, 25, nombre);
                    break;
                case 5:
                    nombre = new Complexe(-2, 0);
                    image.Julia(nom, 2, 25, nombre);
                    break;
                case 6:
                    nombre = new Complexe(0.35f, 0.05f);
                    image.Julia(nom, 2, 25, nombre);
                    break;
                case 7:
                    image.Buddhabrot(nom,2,10000);
                    break;
                default:
                    image.Mandelbrot(nom, 2, 25);
                    break;


            }
            image.From_Scratch_Image_To_File();
        }

        private void CBTypeFractale_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
