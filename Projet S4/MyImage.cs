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

        public Pixel[,] Matrice
        {
            get { return matrice; }
            set { matrice = value; }
        }

        public int Hauteur
        {
            get { return hauteur; }
        }

        public int Largeur
        {
            get { return largeur; }
        }


        public MyImage(string name) //Constructeur à partir d'un fichier existant dans le dossier debug
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

        public MyImage(MyImage image) //Constructeur à partir d'une image (pour réaliser une copie)
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

        public MyImage(int hauteur, int largeur, string nom, Pixel couleur) //contructeur d'une image from scratch
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
                    matrice[i, j] = couleur;
                }
            }
        }

      
        public string AfficherDonnees() //Affiche les données, utile pour les tests au début du projet
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
                    k+=3;
                    //Console.Write(matrice[i, j / 3].AfficherPixel());
                }
                while (k % 4 != 0)
                {
                    newfile.Add(0);
                    k++;
                }

            }
            File.WriteAllBytes(sortie + ".bmp", newfile.ToArray());




        } //Ecrit et enregistre l'image à partir des données d'une image déja existante

        public void From_Scratch_Image_To_File() //Ecrit els données et enregistre l'image from scratch
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
                    k+=3;
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
        } //Affiche une matrice de pixel (pour vérifications)

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
                    if (moyenne < 128)
                    {
                        moyenne = 0;
                    }
                    else
                    {
                        moyenne = 255;
                    }
                    Pixel pix = new Pixel(moyenne, moyenne, moyenne);
                    this.matrice[i, j] = pix;

                }
            }
        } //Transforme la matrice de pixels en pixels noir et blanc.
        public void NuanceDeGris() //Transforme la matrice en pixels grisés
        {
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {

                    byte moyenne = Convert.ToByte((matrice[i, j].Red + matrice[i, j].Green + matrice[i, j].Blue) / 3);
                    Pixel pix = new Pixel(moyenne, moyenne, moyenne);

                    this.matrice[i, j] = pix;

                }
            }
        }  

        public void NuanceDeGrisGrisé() //Version plus accentuée du nuance de gris, non utilisé sur l'application
        {
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {

                    byte moyenne = Convert.ToByte((matrice[i, j].Red + matrice[i, j].Green + matrice[i, j].Blue) / 6);
                    Pixel pix = new Pixel(moyenne, moyenne, moyenne);

                    this.matrice[i, j] = pix;

                }
            }
        }   

        public void Tourner() //Permet une rotation par 90 degrés.
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

        }         


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

        } //Floute l'image (convolution)
        

        public void ContourImage()
        {
            Etendre(1);
            int[,] flou = new int[,] { { -2, -2, -2 }, { -2, 16, -2 }, { -2, -2, -2 } };
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
                    sommeR = sommeR / 3;
                    sommeB = sommeB / 3;
                    sommeV = sommeV / 3;
                    byte rouge = Retourne(sommeR);
                    byte bleu = Retourne(sommeB);
                    byte vert = Retourne(sommeV);
                    //Console.WriteLine(rouge + ";" + bleu + ";" + vert);
                    temp[i-1, j-1] = new Pixel(bleu, vert, rouge);
                }


            }
            for (int i = 0; i < hauteur; i++)
            {

                for (int j = 0; j < largeur; j++)
                {

                    matrice[i, j] = temp[i, j];
                }
            }

        } //contours colorés (convolution)

        public void Repoussage()
        {
            Etendre(1);
            int[,] flou = new int[,] { { -2, -1, 0 }, { -1, 1, 1 }, { 0, 1, 2 } };
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
                    //Console.WriteLine(rouge + ";" + bleu + ";" + vert);
                    temp[i-1, j-1] = new Pixel(bleu, vert, rouge);
                }


            }
            for (int i = 0; i < hauteur; i++)
            {

                for (int j = 0; j < largeur; j++)
                {

                    matrice[i, j] = temp[i, j];
                }
            }

        } //fait ressortir les bords

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

        }   //fonctionne mal, pas présent dans l'appli


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

        public void MiroirVertical()
        {
            Pixel[,] temp = new Pixel[hauteur, largeur];
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    temp[largeur-1-i,j] = matrice[i, j];

                }
            }
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    matrice[i, j] = temp[i, j];

                }
            }

        } //inverse par rapport à l'axe x


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
        }  //Etend les bords de la matrice en copiant les bords actuels, à utiliser pour la convolution


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
                for (int j = 0; j < largeur; j++)
                {
                    mat[Convert.ToInt64(i), Convert.ToInt64(j)] = new Complexe((float)(j - (2.2 * largeur / 3)) / (largeur / 2.5f), (float)(i - hauteur / 2) / (hauteur / 2.5f));
                    //Détermine les valeurs min et max des axes réels et complexes
                }
            }
            //L'idée est de bosser avec en parallèle la matrice de pixel et une matrice de complexe échelonnés entre la valeur max et min qui restent toujours les mêmes.
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    int cpt = 0;
                    Complexe temp = mat[i, j];
                    matrice[i, j] = new Pixel(0, 0, 0); 
                    while (mat[i, j].ModuleCarre <= mod && cpt < n)
                    {
                        mat[i, j] = mat[i, j].CalculZnMandelbrot(temp);

                        matrice[i, j] = new Pixel(Convert.ToByte(matrice[i, j].Blue + 10), Convert.ToByte(matrice[i, j].Green + 1), Convert.ToByte(matrice[i, j].Red + cpt/2)); //Peut être changé, combinaisons de couleurs pour l'affichage

                        cpt++;
                    }
                    if (mat[i, j].ModuleCarre <= mod)
                    {
                        matrice[i, j] = new Pixel(0, 0, 0);
                    }

                }
                float nbTot = 100 * (float)(i * largeur) / (float)(hauteur * largeur);
                Console.WriteLine(nbTot + "%"); //Affiche la progression de la fractale dans la console
            }
        } //Fractale de mandelbrot

        public void Buddhabrot(string nom, double mod, int n)
        {
            Complexe[,] mat = new Complexe[hauteur, largeur];
            for (double i = 0; i < hauteur; i++)
            {

                for (int j = 0; j < largeur; j++)
                {
                    mat[Convert.ToInt64(i), Convert.ToInt64(j)] = new Complexe((float)(j - (2.2 * largeur / 3)) / (largeur / 2.5f), (float)(i - hauteur / 2) / (hauteur / 2.5f));

                }
            }
            //Complexe.AfficherComplexe(mat);
            int[,] densite = new int[hauteur, largeur];

            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    bool verif = false;
                    int cpt = 0;
                    Complexe temp = mat[i, j];
                    Complexe temp2 = temp;
                    while (mat[i, j].ModuleCarre <= mod && cpt < n)

                    {
                        mat[i, j] = mat[i, j].CalculZnMandelbrot(temp);
                        cpt++;
                    }
                    if (mat[i, j].ModuleCarre <= mod)
                    {
                        cpt = 0;
                        mat[i, j] = temp2;
                        while (mat[i, j].ModuleCarre <= mod && cpt < n && verif == false)

                        {
                            mat[i, j] = mat[i, j].CalculZnMandelbrot(temp2);
                            cpt++;
                            if (mat[i, j].Re > -1.8 && mat[i, j].Re < 1.8 && mat[i, j].Im > -1.2 && mat[i, j].Im < 1.2)
                            {
                                densite[(int)((mat[i, j].Re + 1.8) * largeur / 3.6f), (int)(((mat[i, j].Im + 1.25) * hauteur / 2.5f))]++;
                            }
                            else
                            {
                               verif = true;
                            }
                        }

                    }
                }
                float nbTot = 100 * (float)(i * largeur) / (float)(hauteur * largeur);
                Console.WriteLine(nbTot + "%");
            }
            int max = 1;
            for (int i = 1; i < hauteur; i++)
            {
                for (int j = 1; j < largeur; j++)
                {
                    if (densite[i, j] > densite[i - 1, j - 1])
                    {
                        max = densite[i, j];
                    }
                }
            }
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    matrice[i, j] = new Pixel((byte)(255 * densite[i, j] / max), (byte)(255 * densite[i, j] / max), (byte)(255 * densite[i, j] / max));
                }
            }
        } //Pas tout à fait fonctionnel, version plus stylée de mandelbrot. Extrêmement long à faire

        public void Julia(string nom, double mod, int n, Complexe c) //Fractales des ensembles de Julia
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
                    while (mat[i, j].ModuleCarre <= mod && cpt < n)
                    {
                        mat[i, j] = mat[i, j].CalculZnJulia(c);

                        //matrice[i, j] = new Pixel(Convert.ToByte(matrice[i, j].Blue - 10), Convert.ToByte(matrice[i, j].Green + 5), Convert.ToByte(matrice[i, j].Red + 10)); //Bleu/Orange/Noir
                        //matrice[i, j] = new Pixel(Convert.ToByte(matrice[i, j].Blue + 10), Convert.ToByte(matrice[i, j].Green + 10), Convert.ToByte(matrice[i, j].Red + 4)); //Rouge/Blanc/Blanc
                        //matrice[i,j].Blue = RemiseANiveauBleu(i, j, 23);
                        //matrice[i, j] = new Pixel(Convert.ToByte(matrice[i, j].Blue + 5), Convert.ToByte(matrice[i, j].Green + 2), Convert.ToByte(matrice[i, j].Red + 10));//Noir et Rose

                        matrice[i, j] = new Pixel(Convert.ToByte(matrice[i, j].Blue + 10), Convert.ToByte(matrice[i, j].Green + 5), Convert.ToByte((matrice[i, j].Red + 2)));
                        cpt++;
                    }
                    if (mat[i, j].ModuleCarre <= mod)
                    {
                        matrice[i, j] = new Pixel(255, 255, 255);
                    }

                }
                float nbTot = 100 * (float)(i * largeur) / (float)(hauteur * largeur);
                Console.WriteLine(nbTot + "%");
            }
        }

        public void BurningShip(string nom, double mod, int n)
        {
            Complexe[,] mat = new Complexe[hauteur, largeur];
            for (double i = 0; i < hauteur; i++)
            {

                for (int j = 0; j < largeur; j++)
                {
                    mat[Convert.ToInt64(i), Convert.ToInt64(j)] = new Complexe((float)(j - (largeur / 2)) / (largeur / 4), (float)(i - (hauteur / 2)) / (hauteur / 4));

                }
            }
            //Complexe.AfficherComplexe(mat);

            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    int cpt = 0;
                    Complexe temp = mat[i, j];
                    matrice[i, j] = new Pixel(0, 0, 0);       //Bleu
                    while (mat[i, j].ModuleCarre <= mod && cpt < n)
                    {
                        mat[i, j] = mat[i, j].CalculZnBurningShip(temp);

                        matrice[i, j] = new Pixel(Convert.ToByte(matrice[i, j].Blue + 10), Convert.ToByte(matrice[i, j].Green + 5), Convert.ToByte(matrice[i, j].Red + 2));     //Noir/Orange/Bleu

                        cpt++;
                    }
                    if (mat[i, j].ModuleCarre <= mod)
                    {
                        matrice[i, j] = new Pixel(255, 255, 255);
                    }

                }
                float nbTot = 100 * (float)(i * largeur) / (float)(hauteur * largeur);
                Console.WriteLine(nbTot + "%");
            }
        } //Ne fonctionne pas, non présent sur l'appli

        public void HistogrammeLuminosité()
        {
            int[] nbrPxl = new int[256];
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    bool stop = false;
                    int cpt = 0;

                    while (!stop && cpt < 255 * 3 + 1)
                    {
                        if ((matrice[i, j].Red + matrice[i, j].Blue + matrice[i, j].Green) == cpt)
                        {
                            stop = true;
                            nbrPxl[cpt / 3]++;
                        }
                        else
                        {
                            cpt += 3;
                        }

                    }
                }
            }
            int maximum = 0;
            for (int i = 1; i < nbrPxl.Length; i++)
            {
                if (nbrPxl[i] > maximum)
                {
                    maximum = nbrPxl[i];
                }
            }

            MyImage Histo = new MyImage(200, 520, "Histogramme" + nom, new Pixel(0,0,0));
            for (int i = 0; i < Histo.largeur - 8; i++)
            {
                int hauteurBarre = (nbrPxl[i / 2] * 180) / maximum;
                //Console.WriteLine(hauteurBarre);
                for (int j = 0; j < Histo.hauteur; j++)
                {
                    if (hauteurBarre > 0)
                    {
                        Histo.matrice[j, i + 4] = new Pixel(255, 255, 255);
                        hauteurBarre--;
                    }
                    else
                    {
                        Histo.matrice[j, i + 4] = new Pixel(0, 0, 0);
                    }
                }
            }
            Histo.path = "Histogramme" + nom + ".bmp";
            Histo.From_Scratch_Image_To_File();

        } //Histogramme sans les couleurs, pour voir la luminosité de l'image

        public void HistogrammeRGB()
        {
            int[,] nbrPxl = new int[256, 3];
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    bool stop = false;
                    int cptR = 0;
                    int cptB = 0;
                    int cptG = 0;

                    while (!stop && cptR < 256)
                    {
                        if (matrice[i, j].Red == cptR)
                        {
                            stop = true;
                            nbrPxl[cptR, 0]++;
                        }
                        else
                        {
                            cptR++;
                        }
                    }
                    stop = false;
                    while (!stop && cptG < 256)
                    {
                        if (matrice[i, j].Green == cptG)
                        {
                            stop = true;
                            nbrPxl[cptG, 1]++;
                        }
                        else
                        {
                            cptG++;
                        }
                    }
                    stop = false;
                    while (!stop && cptB < 256)
                    {
                        if (matrice[i, j].Blue == cptB)
                        {
                            stop = true;
                            nbrPxl[cptB, 2]++;
                        }
                        else
                        {
                            cptB++;
                        }
                    }
                }
            }
            int maximum = 0;                                //conserve la valeur maximale
            for (int i = 1; i < nbrPxl.GetLength(0); i++)
            {
                for (int j = 0; j < nbrPxl.GetLength(1); j++)
                {
                    if (nbrPxl[i, j] > maximum)
                    {
                        maximum = nbrPxl[i, j];
                    }
                }
            }


            MyImage Histo = new MyImage(200, 520, "Histogramme" + nom, new Pixel(0,0,0));

            for (int i = 0; i < Histo.largeur - 8; i++)
            {
                //Console.WriteLine(hauteurBarre);
                for (int l = 0; l < nbrPxl.GetLength(1); l++)
                {
                    int hauteurBarre = (nbrPxl[i / 2, l] * 180) / maximum;
                    for (int j = 0; j < Histo.hauteur; j++)
                    {
                        if (hauteurBarre > 0)
                        {
                            switch (l)
                            {
                                case 0:
                                    Histo.matrice[j, i + 4] = new Pixel(0, 0, 255);
                                    break;
                                case 1:
                                    Histo.matrice[j, i + 4] = new Pixel(0, 255, Histo.matrice[j, i + 4].Red);
                                    break;
                                case 2:
                                    Histo.matrice[j, i + 4] = new Pixel(255, Histo.matrice[j, i + 4].Green, Histo.matrice[j, i + 4].Red);
                                    break;
                            }
                            hauteurBarre--;
                        }
                        else
                        {
                            switch (l)
                            {
                                case 0:
                                    Histo.matrice[j, i + 4] = new Pixel(0, 0, 0);
                                    break;
                                case 1:
                                    Histo.matrice[j, i + 4] = new Pixel(0, 0, Histo.matrice[j, i + 4].Red);
                                    break;
                                case 2:
                                    Histo.matrice[j, i + 4] = new Pixel(0, Histo.matrice[j, i + 4].Green, Histo.matrice[j, i + 4].Red);
                                    break;
                            }
                        }
                    }

                }
            }


            Histo.path = "Histogramme" + nom + ".bmp";
            Histo.From_Scratch_Image_To_File();

        } //Histogramme classique avec les 3 couleurs

        public static MyImage Steganographie(MyImage host, MyImage hide)//On considère que host est la plus grande des 2 images, fonctionne mal depuis quelques modifications ..?
        {

            MyImage image = new MyImage(host);
            image.nom = "Steganographie_" + host.nom + "_" + hide.nom;
            image.path = image.nom + ".bmp";
            int[,] tabhost = new int[3, 8];
            int[,] tabhide = new int[3, 8];
            for (int i = 0; i < hide.hauteur; i++)
            {
                for (int j = 0; j < hide.largeur; j++)
                {
                    string tabRhost = Program.ByteToBinaryINT(host.matrice[i, j].Red).PadLeft(8,'0');
                    string tabGhost = Program.ByteToBinaryINT(host.matrice[i, j].Green).PadLeft(8, '0');
                    string tabBhost = Program.ByteToBinaryINT(host.matrice[i, j].Blue).PadLeft(8, '0');
                    string tabRhide = Program.ByteToBinaryINT(hide.matrice[i, j].Red).PadLeft(8, '0');
                    string tabGhide = Program.ByteToBinaryINT(hide.matrice[i, j].Green).PadLeft(8, '0');
                    string tabBhide = Program.ByteToBinaryINT(hide.matrice[i, j].Blue).PadLeft(8, '0');
                    for (int k = 0; k < 8; k++) //A refaire pour optimiser (retourne dans la fonction 6 fois par itération)
                    {

                        tabhost[0, k] = tabRhost[k];
                        tabhost[1, k] = tabGhost[k];
                        tabhost[2, k] = tabBhost[k];
                        tabhide[0, k] = tabRhide[k];
                        tabhide[1, k] = tabGhide[k];
                        tabhide[2, k] = tabBhide[k];
                    }
                    int[,] newtab = new int[3, 8];
                    for (int l = 0; l < 3; l++)
                    {
                        newtab[l, 0] = tabhost[l, 0];
                        newtab[l, 1] = tabhost[l, 1];
                        newtab[l, 2] = tabhost[l, 2];
                        newtab[l, 3] = tabhost[l, 3];
                        newtab[l, 4] = tabhide[l, 0];
                        newtab[l, 5] = tabhide[l, 1];
                        newtab[l, 6] = tabhide[l, 2];
                        newtab[l, 7] = tabhide[l, 3];
                    }
                    int[] ntabR = new int[8];
                    int[] ntabB = new int[8];
                    int[] ntabG = new int[8];
                    for (int cpt = 0; cpt < 8; cpt++)
                    {
                        ntabR[cpt] = newtab[0, cpt];
                        ntabG[cpt] = newtab[1, cpt];
                        ntabB[cpt] = newtab[2, cpt];

                    }
                    
                    image.matrice[i, j] = new Pixel(Program.BinaryToByte(ntabB), Program.BinaryToByte(ntabG), Program.BinaryToByte(ntabR));

                }


            }
            /*for (int i = hide.hauteur - 1; i < host.hauteur; i++)
        {
            for (int j = hide.largeur - 1; j < host.largeur; j++)
            {
                image.matrice[i, j] = host.matrice[i, j];
                image.matrice[i - hide.hauteur - 1, j] = host.matrice[i - hide.hauteur - 1, j];
                image.matrice[i, j - hide.largeur - 1] = host.matrice[i, j - hide.largeur - 1];
            }
        }*/
            image.From_Scratch_Image_To_File();
            return image;
        }

        public static void DecrypteStegano(MyImage stegano)
        {
            int[,] tab = new int[3, 8];
            for (int i = 0; i < stegano.hauteur; i++)
            {
                for (int j = 0; j < stegano.largeur; j++)
                {

                    string tabRhost = Program.ByteToBinaryINT(stegano.matrice[i, j].Red).PadLeft(8, '0');
                    string tabGhost = Program.ByteToBinaryINT(stegano.matrice[i, j].Green).PadLeft(8, '0');
                    string tabBhost = Program.ByteToBinaryINT(stegano.matrice[i, j].Blue).PadLeft(8, '0');
                    for (int k = 0; k < 8; k++) //A refaire pour optimiser (retourne dans la fonction 6 fois par itération)
                    {

                        tab[0, k] = tabRhost[k];
                        tab[1, k] = tabGhost[k];
                        tab[2, k] = tabBhost[k];
                    }
                    for (int l = 0; l < 3; l++)
                    {
                        tab[l, 0] = tab[l, 4];
                        tab[l, 1] = tab[l, 5];
                        tab[l, 2] = tab[l, 6];
                        tab[l, 3] = tab[l, 7];
                        tab[l, 4] = 0;
                        tab[l, 5] = 0;
                        tab[l, 6] = 0;
                        tab[l, 7] = 0;
                    }
                    int[] ntabR = new int[8];
                    int[] ntabB = new int[8];
                    int[] ntabG = new int[8];
                    for (int cpt = 0; cpt < 8; cpt++)
                    {
                        ntabR[cpt] = tab[0, cpt];
                        ntabG[cpt] = tab[1, cpt];
                        ntabB[cpt] = tab[2, cpt];

                    }
                    stegano.matrice[i, j] = new Pixel(Program.BinaryToByte(ntabB), Program.BinaryToByte(ntabG), Program.BinaryToByte(ntabR));
                }
                float nbTot = 100 * (float)(i * stegano.largeur) / (float)(stegano.hauteur * stegano.largeur);
                Console.WriteLine(nbTot + "%");
            }
            stegano.nom += "Decryptée";
            stegano.path = stegano.nom + ".bmp";
            stegano.From_Scratch_Image_To_File();

        } //Montre ou était caché l'image dans l'image cryptée

       

    }
}
