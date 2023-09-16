using System;

namespace Projet_S4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*byte[] tab = { 230, 4, 0, 0 };
            Console.WriteLine(Convertir_Endian_To_Int(tab));
            byte[] tab2 = Convertir_Int_To_Endian(1254);
            for (int i = 0; i < tab2.Length; i++)
            {
                Console.Write(tab2[i] + " ");
            }
            MyImage test = new MyImage("lenalenvers");
            Console.WriteLine(test.AfficherDonnees());
            test.AfficherMatPixel();
            test.From_Image_To_File("Aled2");
            Console.ReadKey();

            //MyImage aled = new MyImage("Aled");
            test.AfficherFichier();
            //aled.AfficherFichier();
            Console.ReadKey();

            MyImage Test = new MyImage("coco");
            MyImage copie = new MyImage(Test);
            
         copie.AgrandirImage(0.0625);

         copie.From_Image_To_File("sortie");            //agrandir une image
         Console.WriteLine(copie.AfficherDonnees());
         Console.WriteLine(Test.AfficherDonnees());
         Console.ReadKey();
            
                        copie.ContourImage();                           //contour une image
                        copie.From_Image_To_File("sortiecontour2");
            Console.ReadKey();

            /* copie.Miroir();                                             //miroir une image 
             copie.From_Image_To_File("sortiemiroir");

            // copie.FlouterImage();                                   //flouter l'image
            //copie.EtendreMatrice(1);

            copie.ContourImage();
            copie.Negatif();
            copie.From_Image_To_File("testflou");
            Console.ReadKey();*/

            /*MyImage compo = new MyImage(50,50,"50x50");
            Complexe constante3= new Complexe(-0.63f,0.67f);

            compo.Julia("t", 2, 25, constante3);
            //Complexe constante= new Complexe(-0.76f, 0.12f);
            //compo.Julia("Fractale",100000,25,constante);
            /*Complexe constante2 = new Complexe(-1,0);
            compo.Julia("Fractale", 2, 25, constante2);
            Complexe constante3 = new Complexe(-2,0);
            compo.Julia("Fractale",2,25,constante3);

            compo.From_Scratch_Image_To_File();*/

            MyImage Test = new MyImage("Mandelbrot12");
            MyImage copie = new MyImage(Test);
            copie.HistogrammeLuminosité();
            Console.ReadKey();

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
    }
}
