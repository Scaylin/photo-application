using System;
using System.Collections.Generic;
using System.IO;



namespace Projet_S4
{
    class MyImage
    {
        string nom;
        string path;
        bool ImType;
        int tailleFichier;
        int tailleOffset = 54;
        int hauteur;
        int largeur;
        int nbBitCouleur = 24;
        Pixel[,] matrice;


        public MyImage(string name)
        {
            nom = name;
            this.path = name + ".bmp";
            byte[] myfile = File.ReadAllBytes(path);

            if (myfile[0] == 66 && myfile[1] == 77 && myfile[28] == nbBitCouleur && myfile[29] == 0)
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

            this.matrice = new Pixel[hauteur, largeur];
            Console.WriteLine();
            for (int j = 0; j < hauteur; j++)
            {
                for (int i = 0; i < largeur * 3; i += 3)
                {
                    Pixel pix = new Pixel(myfile[i + 54 + j * largeur * 3], myfile[i + 54 + 1 + j * largeur * 3], myfile[i + 54 + 2 + j * largeur * 3]);
                    matrice[j, (i / 3)] = pix;
                    //Console.Write(j+ ","+ i / 3 + "  ");
                    //Console.Write(matrice[j, (i / 3)].Blue + "," + matrice[j, (i / 3)].Green + "," + matrice[j, (i / 3)].Red +" ");
                }
                //Console.WriteLine();

            }

        }

        public MyImage(MyImage image)
        {
            ImType = true;
            tailleFichier = image.tailleFichier;
            hauteur = image.hauteur;
            largeur = image.largeur;
            matrice = image.matrice;
            nom = image.nom;
            path = nom + ".bmp";
            matrice = image.matrice;
        }

        public MyImage(int hauteur, int largeur, string nom) //contructeur d'une image from scratch
        {
            this.hauteur = hauteur;
            this.largeur = largeur;
            ImType = true;
            this.nom = nom;
            path = nom + ".bmp";
            tailleFichier = 54 + hauteur * largeur * 3;
            matrice = new Pixel[hauteur, largeur];
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    matrice[i, j] = new Pixel(0, 0, 0);
                }
            }
        }

        /*
        public MyImage(string myfile)
        {
            byte[] file = File.ReadAllBytes(myfile);
            Console.WriteLine("Nombre de bytes : " + file.Length);
            this.nom = myfile;
            //myfile est un vecteur composé d'octets représentant les métadonnées et les données de l'image

            //lecture du header et assignement des variables d'instance et des bits par pixels 
            if (file[0] == 66 && file[1] == 77 && file[28] == 24 && file[29] == 0)
            {
                this.ImType = true;
                this.nbBitCouleur = 24;
            }
            else
            {
                this.ImType = false;
            }

            //Conversion de la taille du fichier Little Endian en entier
            byte[] TailleFichier = new byte[4];
            int TF = 2;
            for (int i = 0; i < 4; i++)
            {
                TailleFichier[i] = file[TF];
                TF++;

            }
            this.tailleFichier = Program.Convertir_Endian_To_Int(TailleFichier);

            //Conversion de la largeur 
            byte[] Largeur = new byte[4];
            int TL = 18;
            for (int i = 0; i < 4; i++)
            {
                Largeur[i] = file[TL];
                TL++;
            }
            this.largeur = Program.Convertir_Endian_To_Int(Largeur);
            //Conversion de la hauteur
            byte[] Hauteur = new byte[4];
            int TH = 22;
            for (int i = 0; i < 4; i++)
            {
                Hauteur[i] = file[TH];
                TH++;
            }
            this.hauteur = Program.Convertir_Endian_To_Int(Hauteur);

            //Conversion de la taille offset 
            byte[] TailleOffset = new byte[4];
            int TO = 10;
            for (int i = 0; i < 4; i++)
            {
                TailleOffset[i] = file[TO];
                TO++;
            }
            this.tailleOffset = Program.Convertir_Endian_To_Int(TailleOffset);

            Pixel[,] matrice = new Pixel[hauteur, largeur];
            int k = 54;
            int l = 0;
            for (int i = 0; i < this.hauteur; i++)
            {
                for (int j = 0; j < this.largeur; j++)
                {
                    Pixel pixel = new Pixel(file[k + l], file[k + l + 1], file[k + l + 2]);
                    matrice[i, j] = pixel;
                    l += 3;
                }
            }
            this.matrice = matrice;

        }
        */
        public string AfficherDonnees()
        {
            return "Image Bitmap : " + ImType + "\n" +
                "Taille du fichier : " + tailleFichier + "\n" +
                "Hauteur : " + hauteur + "\n" +
                "Largeur : " + largeur + "\n" +
                "Offset : " + tailleOffset + "\n";
        }

        public void From_Image_To_File(string sortie)
        {
            List<byte> myfile = new List<byte>(File.ReadAllBytes(path));
            List<byte> newfile = new List<byte>();
            byte[] tab = new byte[4];
            for (int i = 0; i < 54; i++)
            {
                newfile.Add(myfile[i]);
            }
            tab = Program.Convertir_Int_To_Endian(tailleFichier);

            for (int i = 5; i >= 2; i--)
            {
                newfile[i] = tab[i - 2];
            }
            tab = Program.Convertir_Int_To_Endian(hauteur);
            for (int i = 25; i >= 22; i--)
            {
                newfile[i] = tab[i - 22];
            }
            tab = Program.Convertir_Int_To_Endian(largeur);
            for (int i = 21; i >= 18; i--)
            {
                newfile[i] = tab[i - 18];
            }
            for (int i = 0; i < hauteur; i++)
            {
                int k = 0;
                for (int j = 0; j < largeur * 3; j += 3)
                {
                    newfile.Add(matrice[i, j / 3].Blue);
                    newfile.Add(matrice[i, j / 3].Green);
                    newfile.Add(matrice[i, j / 3].Red);
                    k++;
                    //Console.Write(matrice[i, j / 3].AfficherPixel());
                }
                while (k % 4 != 0)
                {
                    newfile.Add(0);
                    k++;
                }

            }
            File.WriteAllBytes(sortie + ".bmp", newfile.ToArray());




        }

        public void From_Scratch_Image_To_File()
        {
            List<byte> myfile = new List<byte>();
            myfile.Add(66);
            myfile.Add(77);
            byte[] tab = Program.Convertir_Int_To_Endian(tailleFichier);
            for (int i = 0; i < 4; i++)
            {
                myfile.Add(tab[i]);
            }
            for (int i = 0; i < 4; i++)
            {
                myfile.Add(0);
            }
            myfile.Add(54);
            myfile.Add(0);
            myfile.Add(0);
            myfile.Add(0);
            myfile.Add(40);
            myfile.Add(0);
            myfile.Add(0);
            myfile.Add(0);
            tab = Program.Convertir_Int_To_Endian(largeur);
            for (int i = 0; i < 4; i++)
            {
                myfile.Add(tab[i]);
            }
            tab = Program.Convertir_Int_To_Endian(hauteur);
            for (int i = 0; i < 4; i++)
            {
                myfile.Add(tab[i]);
            }
            myfile.Add(1);
            myfile.Add(0);
            myfile.Add(24);
            myfile.Add(0);
            for (int i = 0; i < 4; i++)
            {
                myfile.Add(0);
            }
            tab = Program.Convertir_Int_To_Endian(hauteur * largeur * 3);
            for (int i = 0; i < 4; i++)
            {
                myfile.Add(tab[i]);
            }
            while (myfile.Count < 54)
            {
                myfile.Add(0);
            }
            for (int i = 0; i < hauteur; i++)
            {
                int k = 0;
                for (int j = 0; j < largeur * 3; j += 3)
                {
                    myfile.Add(matrice[i, j / 3].Blue);
                    myfile.Add(matrice[i, j / 3].Green);
                    myfile.Add(matrice[i, j / 3].Red);
                    k++;
                    //Console.Write(matrice[i, j / 3].AfficherPixel());


                }
                while (k % 4 != 0)
                {
                    myfile.Add(0);
                    k++;
                }

            }

            File.WriteAllBytes(path, myfile.ToArray());

        }

        /*public void From_Image_To_File(string file)
        {
            // Lecture du Header
            byte[] FileSave = new byte[54 + (matrice.Length*3)];
            byte[] fileCopy = File.ReadAllBytes("Coco.bmp");
            for (int i = 0; i < 54; i++)    //Construction du header
            {
                FileSave[i] = fileCopy[i];
            }

            for (int i = 0; i < 4; i++) // On modifie les données sur les dimensions de l'image et la taille du fichier
            {
                FileSave[2 + i] = Program.Convertir_Int_To_Endian((matrice.Length*3) + 54)[i]; // Nouvelle taille du fichier
                FileSave[18 + i] = Program.Convertir_Int_To_Endian(matrice.GetLength(1))[i]; // Nouvelle largeur de l'image 
                FileSave[22 + i] = Program.Convertir_Int_To_Endian(matrice.GetLength(0))[i]; // Nouvelle hauteur de l'image
                FileSave[35 + i] = Program.Convertir_Int_To_Endian(matrice.Length)[i]; // Nouvelle taille de l'image                                                                // 
            }

            // Lecture de l'image elle même
            int k = 54;
            int l = 0;
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    FileSave[k + l] = this.matrice[i, j].Blue;
                    FileSave[k + l + 1] = this.matrice[i, j].Green;
                    FileSave[k + l + 2] = this.matrice[i, j].Red;
                    l += 3;
                }
            }

            // Ecriture dans le fichier
            File.WriteAllBytes("sortie.bmp", FileSave);



        }*/


        public void AfficherMatPixel()
        {

            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur * 3; j += 3)
                {

                    Console.Write(matrice[i, j / 3].AfficherPixel() + " ");

                }
                Console.WriteLine();
            }
        }

        public void AfficherFichier()
        {
            byte[] myfile = File.ReadAllBytes(path);

            Console.WriteLine("\n Header \n");
            for (int i = 0; i < 14; i++)
            {
                Console.Write(myfile[i] + " ");
            }
            Console.WriteLine("\n Header Info \n");
            for (int i = 14; i < 54; i++)
            {
                Console.Write(myfile[i] + " ");
            }
            Console.WriteLine("\n Image \n");
            for (int i = 54; i < myfile.Length; i = i + largeur * 3)
            {
                for (int j = i; j < i + largeur * 3; j++)
                {

                    Console.Write(myfile[j] + " ");


                }
                Console.WriteLine();
            }

        }
        public void NoirEtBlanc()
        {
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {

                    byte moyenne = Convert.ToByte((matrice[i, j].Red + matrice[i, j].Green + matrice[i, j].Blue) / 3);
                    if(moyenne<128)
                    {
                        moyenne = 0;
                    }
                    else
                    {
                        moyenne = 255;
                    }
                    Pixel pix = new Pixel(moyenne, moyenne, moyenne);
                    /*this.matrice[i, j].Red = moyenne;
                    this.matrice[i, j].Blue = moyenne;
                    this.matrice[i, j].Green = moyenne;*/
                    this.matrice[i, j] = pix;

                }
            }
        }
        public void NuanceDeGris()
        {
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {

                    byte moyenne = Convert.ToByte((matrice[i, j].Red + matrice[i, j].Green + matrice[i, j].Blue) / 3);
                    Pixel pix = new Pixel(moyenne, moyenne, moyenne);
                    /*this.matrice[i, j].Red = moyenne;
                    this.matrice[i, j].Blue = moyenne;
                    this.matrice[i, j].Green = moyenne;*/
                    this.matrice[i, j] = pix;

                }
            }
        }   //noir et blanc

        public void NuanceDeGrisGrisé()
        {
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {

                    byte moyenne = Convert.ToByte((matrice[i, j].Red + matrice[i, j].Green + matrice[i, j].Blue) / 6);
                    Pixel pix = new Pixel(moyenne, moyenne, moyenne);
                    /*this.matrice[i, j].Red = moyenne;
                    this.matrice[i, j].Blue = moyenne;
                    this.matrice[i, j].Green = moyenne;*/
                    this.matrice[i, j] = pix;

                }
            }
        }   //version plus douce du noir et blanc ou tout est plus grisé

        public void Tourner()
        {

            Pixel[,] rotation = new Pixel[largeur, hauteur];
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    rotation[j, hauteur - i - 1] = matrice[i, j];
                }
            }
            int temp = hauteur;
            hauteur = largeur;
            largeur = temp;
            matrice = new Pixel[hauteur, largeur];
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    matrice[i, j] = rotation[i, j];
                }
            }

        }   //tourne image à 90degrés

        public static void Tourner(Complexe[,] MAT)
        {
            int h = MAT.GetLength(0);
            int l = MAT.GetLength(1);
            Complexe[,] rotation = new Complexe[h, l];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    rotation[j, h - i - 1] = MAT[i, j];
                }
            }
            int temp = h;
            h = l;
            l = temp;
            MAT = new Complexe[h, l];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    MAT[i, j] = rotation[i, j];
                }
            }

        }   //tourne image à 90degrés


        public void AgrandirImage(double ratio)
        {
            hauteur = Convert.ToInt32(hauteur * ratio);
            largeur = Convert.ToInt32(largeur * ratio);
            Pixel[,] grand = new Pixel[hauteur, largeur];
            for (int i = 0; i < hauteur; i++)
            {

                for (int j = 0; j < largeur; j++)
                {
                    grand[i, j] = matrice[Convert.ToInt32(Math.Floor(i / ratio)), Convert.ToInt32(Math.Floor(j / ratio))];
                }
            }
            matrice = new Pixel[hauteur, largeur];
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    matrice[i, j] = grand[i, j];
                }
            }
        } //agrandit ou rétrécit l'image selon le ratio

        public void FlouterImage()
        {
            Etendre(2);
            int[,] flou = new int[,] { { 2, 4, 5, 4, 2 }, { 4, 9, 12, 9, 4 }, { 5, 12, 15, 12, 5 }, { 4, 9, 12, 9, 4 }, { 2, 4, 5, 4, 1 } };
            Pixel[,] temp = new Pixel[hauteur, largeur];
            for (int i = 2; i < hauteur + 2; i++)
            {
                int sommeR = 0;
                int sommeB = 0;
                int sommeV = 0;
                for (int j = 2; j < largeur + 2; j++)
                {
                    for (int k = 0; k <= 2; k++)
                    {
                        for (int l = 0; l <= 2; l++)
                        {
                            sommeR += flou[k, l] * Convert.ToInt32(matrice[k + i - 2, j + l - 2].Red);
                            sommeB += flou[k, l] * Convert.ToInt32(matrice[k + i - 2, j + l - 2].Blue);
                            sommeV += flou[k, l] * Convert.ToInt32(matrice[k + i - 2, j + l - 2].Green);
                        }
                    }
                    sommeR = sommeR / 69;
                    sommeB = sommeB / 69;
                    sommeV = sommeV / 69;
                    byte rouge = Retourne(sommeR);
                    byte bleu = Retourne(sommeB);
                    byte vert = Retourne(sommeV);
                    //Console.WriteLine(rouge + ";" + bleu + ";" + vert);
                    temp[i - 2, j - 2] = new Pixel(bleu, vert, rouge);
                }


            }
            matrice = new Pixel[hauteur, largeur];
            for (int i = 0; i < hauteur; i++)
            {

                for (int j = 0; j < largeur; j++)
                {
                    matrice[i, j] = temp[i, j];
                }
            }

        }

        /*   public void FlouterImage2() 
           {
               Etendre(2);
               int[,] flou = new int[,] { { 0, 0, 0, 0, 0 }, { 0, 1, 1, 1, 0 }, { 0, 1, 1, 1, 0 }, { 0, 1, 1, 1, 0 }, { 0, 0, 0, 0, 0 } };
               Pixel[,] temp = new Pixel[hauteur, largeur];
               for (int i = 2; i < hauteur + 2; i++)
               {
                   int sommeR = 0;
                   int sommeB = 0;
                   int sommeV = 0;
                   for (int j = 2; j < largeur + 2; j++)
                   {
                       for (int k = 0; k <= 2; k++)
                       {
                           for (int l = 0; l <= 2; l++)
                           {
                               sommeR += flou[k, l] * Convert.ToInt32(matrice[k + i - 2, j + l - 2].Red);
                               sommeB += flou[k, l] * Convert.ToInt32(matrice[k + i - 2, j + l - 2].Blue);
                               sommeV += flou[k, l] * Convert.ToInt32(matrice[k + i - 2, j + l - 2].Green);
                           }
                       }
                       sommeR = sommeR / 5;
                       sommeB = sommeB / 5;
                       sommeV = sommeV / 5;
                       byte rouge = Retourne(sommeR);
                       byte bleu = Retourne(sommeB);
                       byte vert = Retourne(sommeV);
                       //Console.WriteLine(rouge + ";" + bleu + ";" + vert);
                       temp[i-2, j-2] = new Pixel(bleu, vert, rouge);
                   }


               }
               matrice = new Pixel[hauteur, largeur];
               for (int i = 0; i < hauteur; i++)
               {

                   for (int j = 0; j < largeur; j++)
                   {
                       matrice[i, j] = temp[i, j];
                   }
               }

           }*/  //fonctionne moins bien quand plusieurs itérations

        public void ContourImage()
        {
            int[,] flou = new int[,] { { -2, -2, -2 }, { -2, 16, -2 }, { -2, -2, -2 } };
            Pixel[,] temp = new Pixel[hauteur, largeur];
            for (int i = 1; i < hauteur - 1; i++)
            {
                int sommeR = 0;
                int sommeB = 0;
                int sommeV = 0;
                for (int j = 1; j < largeur - 1; j++)
                {
                    for (int k = 0; k <= 2; k++)
                    {
                        for (int l = 0; l <= 2; l++)
                        {
                            sommeR += flou[k, l] * Convert.ToInt32(matrice[k + i - 1, j + l - 1].Red);
                            sommeB += flou[k, l] * Convert.ToInt32(matrice[k + i - 1, j + l - 1].Blue);
                            sommeV += flou[k, l] * Convert.ToInt32(matrice[k + i - 1, j + l - 1].Green);
                        }
                    }
                    sommeR = sommeR / 3;
                    sommeB = sommeB / 3;
                    sommeV = sommeV / 3;
                    byte rouge = Retourne(sommeR);
                    byte bleu = Retourne(sommeB);
                    byte vert = Retourne(sommeV);
                    //Console.WriteLine(rouge + ";" + bleu + ";" + vert);
                    temp[i, j] = new Pixel(bleu, vert, rouge);
                }


            }
            for (int i = 1; i < matrice.GetLength(0) - 1; i++)
            {

                for (int j = 1; j < matrice.GetLength(1) - 1; j++)
                {

                    matrice[i, j] = temp[i, j];
                }
            }

        } //contours colorés

        public void Repoussage()
        {
            int[,] flou = new int[,] { { -2, -1, 0 }, { -1, 1, 1 }, { 0, 1, 2 } };
            Pixel[,] temp = new Pixel[hauteur, largeur];
            for (int i = 1; i < hauteur - 1; i++)
            {
                int sommeR = 0;
                int sommeB = 0;
                int sommeV = 0;
                for (int j = 1; j < largeur - 1; j++)
                {
                    for (int k = 0; k <= 2; k++)
                    {
                        for (int l = 0; l <= 2; l++)
                        {
                            sommeR += flou[k, l] * Convert.ToInt32(matrice[k + i - 1, j + l - 1].Red);
                            sommeB += flou[k, l] * Convert.ToInt32(matrice[k + i - 1, j + l - 1].Blue);
                            sommeV += flou[k, l] * Convert.ToInt32(matrice[k + i - 1, j + l - 1].Green);
                        }
                    }
                    sommeR = sommeR / 2;
                    sommeB = sommeB / 2;
                    sommeV = sommeV / 2;
                    byte rouge = Retourne(sommeR);
                    byte bleu = Retourne(sommeB);
                    byte vert = Retourne(sommeV);
                    //Console.WriteLine(rouge + ";" + bleu + ";" + vert);
                    temp[i, j] = new Pixel(bleu, vert, rouge);
                }


            }
            for (int i = 1; i < matrice.GetLength(0) - 1; i++)
            {

                for (int j = 1; j < matrice.GetLength(1) - 1; j++)
                {

                    matrice[i, j] = temp[i, j];
                }
            }

        } //revoir utilité

        public void Sobel()
        {
            Etendre(1);
            int[,] flou = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 0 } };
            Pixel[,] temp = new Pixel[hauteur, largeur];
            for (int i = 1; i < hauteur + 1; i++)
            {
                int sommeR = 0;
                int sommeB = 0;
                int sommeV = 0;
                for (int j = 1; j < largeur + 1; j++)
                {
                    for (int k = 0; k <= 2; k++)
                    {
                        for (int l = 0; l <= 2; l++)
                        {
                            sommeR += flou[k, l] * Convert.ToInt32(matrice[k + i - 1, j + l - 1].Red);
                            sommeB += flou[k, l] * Convert.ToInt32(matrice[k + i - 1, j + l - 1].Blue);
                            sommeV += flou[k, l] * Convert.ToInt32(matrice[k + i - 1, j + l - 1].Green);
                        }
                    }

                    byte rouge = Retourne(sommeR);
                    byte bleu = Retourne(sommeB);
                    byte vert = Retourne(sommeV);
                    //Console.WriteLine(rouge + ";" + bleu + ";" + vert);
                    temp[i - 1, j - 1] = new Pixel(bleu, vert, rouge);
                }


            }
            for (int i = 0; i < hauteur; i++)
            {

                for (int j = 0; j < largeur; j++)
                {

                    matrice[i, j] = temp[i, j];
                }
            }

        }   //à revoir


        public void ContourImage2()
        {
            Etendre(1);
            int[,] flou = new int[,] { { 0, 1, 0 }, { 1, -4, 1 }, { 0, 1, 0 } };
            Pixel[,] temp = new Pixel[hauteur, largeur];
            for (int i = 1; i < hauteur + 1; i++)
            {
                int sommeR = 0;
                int sommeB = 0;
                int sommeV = 0;
                for (int j = 1; j < largeur + 1; j++)
                {
                    for (int k = 0; k <= 2; k++)
                    {
                        for (int l = 0; l <= 2; l++)
                        {
                            sommeR += flou[k, l] * Convert.ToInt32(matrice[k + i - 1, j + l - 1].Red);
                            sommeB += flou[k, l] * Convert.ToInt32(matrice[k + i - 1, j + l - 1].Blue);
                            sommeV += flou[k, l] * Convert.ToInt32(matrice[k + i - 1, j + l - 1].Green);
                        }
                    }
                    sommeR = sommeR / 2;
                    sommeB = sommeB / 2;
                    sommeV = sommeV / 2;
                    byte rouge = Retourne(sommeR);
                    byte bleu = Retourne(sommeB);
                    byte vert = Retourne(sommeV);
                    if (rouge < 15 && vert < 15 && bleu < 15)
                    {
                    }
                    else
                    {
                        bleu = 226;
                        rouge = 226;
                        vert = 226;
                    }
                    //Console.WriteLine(rouge + ";" + bleu + ";" + vert);
                    temp[i - 1, j - 1] = new Pixel(bleu, vert, rouge);
                }


            }
            matrice = new Pixel[hauteur, largeur];
            for (int i = 0; i < hauteur; i++)
            {

                for (int j = 0; j < largeur; j++)
                {

                    matrice[i, j] = temp[i, j];
                }
            }

        }   //contours en noir et blanc
        public void Miroir()
        {
            Pixel[,] temp = new Pixel[hauteur, largeur];
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    temp[i, largeur - 1 - j] = matrice[i, j];

                }
            }
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    matrice[i, j] = temp[i, j];

                }
            }

        } //inverse par rapport à l'axe y 


        public byte Retourne(int val)
        {
            if (val < 0)
            {
                return 0;
            }
            else if (val >= 256)
            {
                return 255;
            }
            else
            {
                return Convert.ToByte(val);
            }
        }   //empeche les valeurs de dépasser 0 ou 255

        /*    public void EtendreMatrice(int entier)                      //à revoir
            {
                Pixel[,] extend = new Pixel[hauteur + 2 * entier, largeur + 2 * entier];

                for (int i = 0; i < hauteur + 2 * entier; i++)
                {
                    for (int j = 0; j < largeur + 2 * entier; j++)
                    {
                        if (i < entier || i >= entier + hauteur)
                        {
                            extend[i, j] = new Pixel(0, 0, 0);
                        }
                        else if (j < entier || j >= entier + largeur)
                        {
                            extend[i, j] = new Pixel(0, 0, 0);
                        }
                        else
                        {
                            extend[i, j] = matrice[i - entier, j - entier];
                        }

                    }
                }
                matrice = new Pixel[hauteur + 2 * entier, largeur + 2 * entier];
                for (int i = 0; i < hauteur + 2 * entier; i++)
                {
                    for (int j = 0; j < largeur + 2 * entier; j++)
                    {
                        matrice[i, j] = extend[i, j];
                    }
                }
            }
        */
        public void Etendre(int nombre)
        {

            Pixel[,] nouvelle = new Pixel[hauteur + 2 * nombre, largeur + 2 * nombre];
            for (int i = nombre; i < hauteur + nombre; i++)
            {
                for (int j = nombre; j < largeur + nombre; j++)
                {
                    nouvelle[i, j] = matrice[i - nombre, j - nombre];
                }
            }
            for (int i = nombre; i < hauteur + nombre; i++)
            {
                for (int j = nombre - 1; j >= 0; j--)
                {
                    nouvelle[i, j] = nouvelle[i, j + 1];
                }
                for (int j = largeur + nombre; j < largeur + nombre * 2; j++)
                {
                    nouvelle[i, j] = nouvelle[i, j - 1];
                }
            }
            for (int j = 0; j < largeur + 2 * nombre; j++)
            {
                for (int i = nombre - 1; i >= 0; i--)
                {
                    nouvelle[i, j] = nouvelle[i + 1, j];
                }
                for (int i = hauteur + nombre; i < hauteur + nombre * 2; i++)
                {
                    nouvelle[i, j] = nouvelle[i - 1, j];
                }
            }
            matrice = new Pixel[hauteur + 2 * nombre, largeur + 2 * nombre];
            matrice = nouvelle;
        }           //utiliser cette fonction

        /*  public void Raccourcir(int nombre)
          {
              Pixel[,] temp = new Pixel[hauteur, largeur];
              for(int i =0;i<hauteur;i++)
              {
                  for (int j = 0; j < largeur; j++)
                  {
                      temp[i, j] = matrice[i + nombre, j + nombre];
                  }
              }
              matrice = new Pixel[hauteur,largeur]; 
              for(int i =0;i<hauteur;i++)
              {
                  for(int j = 0; j<largeur;j++)
                  {
                      matrice[i, j] = temp[i, j];
                  }
              }
          }       //inutile actuellement*/ //inutile actuellement


        public void Negatif()
        {
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    matrice[i, j] = new Pixel(Convert.ToByte(255 - matrice[i, j].Blue), Convert.ToByte(255 - matrice[i, j].Green), Convert.ToByte(255 - matrice[i, j].Red));
                }
            }
        }   //inversion de couleur

        public void Mandelbrot(string nom, double mod, int n)
        {
            Complexe[,] mat = new Complexe[hauteur, largeur];
            for (double i = 0; i < hauteur; i++)
            {
                /*if (i < hauteur / 2)
                {
                    for (double j = 0; j < largeur; j++)
                    {
                        if (j < 3 * largeur / 4)
                        {
                            mat[Convert.ToInt64(i), Convert.ToInt64(j)] = new Complexe((float)(j- (2 * largeur / 3)) / (largeur / 3), (float)(i - hauteur / 2) / (hauteur / 3));
                        }
                        else
                        {
                            mat[Convert.ToInt64(i), Convert.ToInt64(j)] = new Complexe((float)(j - (2 * largeur / 3)) / (largeur / 3), (float)(i - hauteur / 2) / (hauteur / 3));
                        }

                    }

                }
                else
                {
                    for (double j = 0; j < largeur; j++)
                    {
                        if (j < 3 * largeur / 4)
                        {
                            mat[Convert.ToInt64(i), Convert.ToInt64(j)] = new Complexe((float)(j- (2 * largeur / 3)) / (largeur / 3), (float)(i - hauteur / 2) / (hauteur / 3));
                        }
                        else
                        {
                            mat[Convert.ToInt64(i), Convert.ToInt64(j)] = new Complexe((float)(j - (2 * largeur / 3)) / (largeur / 3), (float)(i - hauteur / 2) / (hauteur / 3));
                        }

                    }
                }*/
                for (int j = 0; j < largeur; j++)
                {
                    mat[Convert.ToInt64(i), Convert.ToInt64(j)] = new Complexe((float)(j - (2.2 * largeur / 3)) / (largeur / 2.5f), (float)(i - hauteur / 2) / (hauteur / 2.5f));

                }
            }
            //Complexe.AfficherComplexe(mat);

            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    int cpt = 0;
                    Complexe temp = mat[i, j];
                    matrice[i, j] = new Pixel(180, 0, 0);       //Bleu
                    while (mat[i, j].Module <= mod && cpt < n)
                    {
                        mat[i, j] = mat[i, j].CalculZnMandelbrot(temp);

                        matrice[i, j] = new Pixel(Convert.ToByte(matrice[i, j].Blue - 0.5), Convert.ToByte(matrice[i, j].Green + 1), Convert.ToByte(matrice[i, j].Red + 1));     //Noir/Orange/Bleu

                        cpt++;
                    }
                    if (mat[i, j].Module <= mod)
                    {
                        matrice[i, j] = new Pixel(0, 0, 0);
                    }

                }
            }
        }

        public void Julia(string nom, double mod, int n, Complexe c)
        {
            Complexe[,] mat = new Complexe[hauteur, largeur];
            for (double i = 0; i < hauteur; i++)
            {

                for (int j = 0; j < largeur; j++)
                {
                    mat[Convert.ToInt64(i), Convert.ToInt64(j)] = new Complexe((float)(j - 1.5f * (largeur / 3)) / (largeur / 4), (float)(i - hauteur / 2) / (hauteur / 4));

                }
            }
            //Complexe.AfficherComplexe(mat);

            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    int cpt = 0;
                    Complexe temp = mat[i, j];
                    //matrice[i, j] = new Pixel(255, 0, 0);         //Bleu 
                    //matrice[i, j] = new Pixel(0, 0, 150);         //Rouge
                    matrice[i, j] = new Pixel(0, 0, 0);
                    while (mat[i, j].Module <= mod && cpt < n)
                    {
                        mat[i, j] = mat[i, j].CalculZnJulia(c);

                        //matrice[i, j] = new Pixel(Convert.ToByte(matrice[i, j].Blue - 10), Convert.ToByte(matrice[i, j].Green + 5), Convert.ToByte(matrice[i, j].Red + 10)); //Bleu/Orange/Noir
                        //matrice[i, j] = new Pixel(Convert.ToByte(matrice[i, j].Blue + 10), Convert.ToByte(matrice[i, j].Green + 10), Convert.ToByte(matrice[i, j].Red + 4)); //Rouge/Blanc/Blanc
                        //matrice[i,j].Blue = RemiseANiveauBleu(i, j, 23);
                        matrice[i, j] = new Pixel(Convert.ToByte(matrice[i, j].Blue + 5), Convert.ToByte(matrice[i, j].Green + 2), Convert.ToByte(matrice[i, j].Red + 10));


                        cpt++;
                    }
                    if (mat[i, j].Module <= mod)
                    {
                        //matrice[i, j] = new Pixel(0, 0, 0);   //Noir
                        //matrice[i, j] = new Pixel(255, 255, 255); //Blanc
                        matrice[i, j] = new Pixel(255, 255, 255);
                    }

                }
            }
        }

        public byte RemiseANiveauBleu(int i, int j, int ajout)
        {
            while (matrice[i, j].Blue + ajout > 255)
            {
                matrice[i, j].Blue = Convert.ToByte(matrice[i, j].Blue - 255);
            }

            while (matrice[i, j].Blue + ajout < 0)
            {
                matrice[i, j].Blue += 255;
            }
            return matrice[i, j].Blue;
        }

        public void HistogrammeLuminosité()
        {
            int[] nbrPxl = new int[256];
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    bool stop = false;
                        int cpt = 0;

                    while (!stop && cpt<255*3+1)
                    {
                        if ((matrice[i, j].Red + matrice[i, j].Blue + matrice[i, j].Green)==cpt)
                        {
                            stop = true;
                            nbrPxl[cpt/3]++;
                        }
                        else
                        {
                            cpt ++;
                        }

                    }
                }
            }
            int maximum = 0;
            for(int i =1;i<nbrPxl.Length;i++)
            {
                if(nbrPxl[i]>maximum)
                {
                    maximum = nbrPxl[i];
                }
            }

            MyImage Histo = new MyImage(200, 520, "Histogramme" + nom);
            for(int i=0;i<Histo.largeur-8;i++)
            {
                int hauteurBarre = (nbrPxl[i/2] * 180) / maximum;
                //Console.WriteLine(hauteurBarre);
                for (int j = 0; j < Histo.hauteur; j++)
                {
                    if(hauteurBarre>0)
                    {
                        Histo.matrice[j,i+4] = new Pixel(255, 255, 255);
                        hauteurBarre--;
                    }
                    else
                    {
                        Histo.matrice[j,i+4] = new Pixel(0, 0, 0);
                    }
                }
            }
            Histo.path = "Histogramme" + nom + ".bmp";
            Histo.From_Scratch_Image_To_File();

        }
    }
}
