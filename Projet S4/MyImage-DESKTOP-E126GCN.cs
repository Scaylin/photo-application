using System.IO;


namespace Projet_S4
{
    class MyImage
    {
        bool ImType;
        int tailleFichier;
        int tailleOffset;
        int hauteur;
        int largeur;
        const int nbBitCouleur = 24;
        Pixel[,] matrice;
         
        public MyImage(string path)
        {
            byte[] myfile = File.ReadAllBytes(path);

            if (myfile[0] == 66 && myfile[1] == 77)
            {
                ImType = true;
            }
            else
            {
                ImType = false;
            }
            byte[] tf = new byte[4];
            for (int i = 2; i <= 5; i++)
            {
                tf[i - 2] = myfile[i];
            }
            tailleFichier = Program.Convertir_Endian_To_Int(tf);
            for (int i = 22; i <= 25; i++)
            {
                tf[i - 22] = myfile[i];
            }
            hauteur = Program.Convertir_Endian_To_Int(tf);
            for (int i = 18; i <= 21; i++)
            {
                tf[i - 18] = myfile[i];
            }
            largeur = Program.Convertir_Endian_To_Int(tf);
            
            matrice = new Pixel[hauteur,largeur*3];            
            for (int j = 0; j < hauteur; j++)
            {
                for (int i = 54; i < largeur * 3; i += 3)
                {
                    Pixel pix = new Pixel(myfile[i], myfile[i + 1], myfile[i + 2]);
                    matrice[j, i - 54].Red = pix.Red;
                    matrice[j, i - 54].Green = pix.Green;
                    matrice[j, i - 54].Blue = pix.Blue;
                }

            }
        }

        public string AfficherDonnees()
        {
            return "Image Bitmap : " + ImType + "\n" +
                "Taille du fichier : " + tailleFichier + "\n" +
                "Hauteur : " + hauteur + "\n" +
                "Largeur : " + largeur + "\n" +
                "Offset : " + tailleOffset +"\n";
        }




    }
}
