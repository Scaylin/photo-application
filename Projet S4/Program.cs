using System;
namespace Projet_S4
{
    class Program
    {
        static void Main(string[] args)
        {

            AppliMyImage app = new AppliMyImage();
            app.ShowDialog();
           

        }



        public static int Convertir_Endian_To_Int(byte[] tab)
        {
            int somme = 0;
            for (int power = 0; power < tab.Length; power++)
            {
                somme += tab[power] * Convert.ToInt32(Math.Pow(256, power));
            }
            return somme;
        }

        public static byte[] Convertir_Int_To_Endian(int val)
        {
            int temp;
            byte[] tab = new byte[4];
            tab[3] = Convert.ToByte(temp = val / (256 * 256 * 256));
            if (temp != 0)
            {
                val -= temp * 256 * 256 * 256;
            }

            tab[2] = Convert.ToByte(temp = val / (256 * 256));

            if (temp != 0)
            {
                val -= temp * 256 * 256;
            }
            tab[1] = Convert.ToByte(temp = val / (256));

            if (temp != 0)
            {
                val -= temp * (256);
            }
            tab[0] = Convert.ToByte(val);
            return tab;
        }

        public static string ByteToBinary(byte val) //Renvoie un string de 0 et de 1 à partir d'un byte
        {


            string res = "";
            int quotient = -1;

            while (quotient != 0)
            {
                quotient = val / 2;
                int reste = val % 2;
                res += Convert.ToString(reste);

                val = (byte)quotient;
            }
            string res2 = "";
            for (int i = 0; i < res.Length; i++)
            {
                res2 += res[res.Length - 1 - i];
            }
            return res2;
        }

        public static string ByteToBinaryINT(int val) //Renvoie un string de 0 et de 1 à partir d'un int
        {


            string res = "";
            int quotient = -1;

            while (quotient != 0)
            {
                quotient = val / 2;
                int reste = val % 2;
                res += Convert.ToString(reste);

                val = quotient;
            }
            string res2 = "";
            for (int i = 0; i < res.Length; i++)
            {
                res2 += res[res.Length - 1 - i];
            }
            return res2;
        }

        public static byte BinaryToByte(int[] tab) //Renvoie un byte à partir d'un tableau de int
        {
            int somme = 0;
            for (int i = 0; i < 8; i++)
            {
                somme += tab[i] * (int)Math.Pow(2, 7 - i);
            }
            return (byte)somme;
        }

        public static string tabEnString(int[] tab) //Convertit un tableau d'entier en string
        {
            string cool = "";
            for (int i = 0; i < tab.Length; i++)
            {
                cool += tab[i];
            }
            return cool;
        }
    }
}
