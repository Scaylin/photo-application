using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_S4
{
    class Pixel
    {
        byte red;
        byte green;
        byte blue;

        public byte Red
        {
            get { return red;  }
            set { value = red;  }
        }
        public byte Green
        {
            get { return green; }
            set { value = green; }
        }
        public byte Blue
        {
            get { return blue; }
            set { value = blue; }
        }
        public Pixel(byte bleu, byte vert, byte rouge)
        {
            red = rouge;
            green = vert;
            blue = bleu;
        }

        public string AfficherPixel()
        {
            return Blue + "," + Green + "," + Red;
        }

        public byte RandomPixel(int min, int max, Random alea)
        {
            byte lezgo = (byte)alea.Next(min, max);
            return lezgo;
        }
    }
}
