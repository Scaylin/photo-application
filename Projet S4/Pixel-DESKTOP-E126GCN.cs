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
            set { red = value;  }
        }
        public byte Green
        {
            get { return green; }
            set { green = value; }
        }
        public byte Blue
        {
            get { return blue; }
            set { blue = value; }
        }
        public Pixel(byte rouge, byte vert, byte bleu)
        {
            red = rouge;
            green = vert;
            blue = bleu;
        }
    }
}
