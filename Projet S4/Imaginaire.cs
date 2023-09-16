using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_S4
{
    class Complexe //Classe utile pour les fractales
    {
        float re;
        float im;
        float moduleCarre;

        public float Re
        {
            get { return re; }
            set { re = value; }
        }

        public float Im
        {
            get { return im; }
            set { im = value; }
        }

        public float ModuleCarre
        {
            get { return moduleCarre; }
            set { moduleCarre = value; }
        }

        public Complexe(float reel, float imaginaire)
        {
            re = reel;
            im = imaginaire;
            moduleCarre = (float)(Math.Sqrt(re * re + im * im));
        }

        public Complexe CalculZnMandelbrot(Complexe z0)
        {
            return new Complexe(Re * re - im * im + z0.re, 2 * re * im + z0.im);
        }
        public Complexe CalculZnJulia(Complexe C)
        {
            return new Complexe(Re * re - im * im + C.Re, 2 * re * im +C.Im );
        }

        public Complexe CalculZnBurningShip(Complexe z0)
        {

            return new Complexe(moduleCarre*moduleCarre+z0.re,z0.im);
        }
        public static void AfficherComplexe(Complexe[,] z)
        {
            for(int i =0;i<z.GetLength(0);i++)
            {
                for(int j = 0;j<z.GetLength(1);j++)
                {
                    Console.Write(z[i, j].re + "+i" + z[i, j].im+"   ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
