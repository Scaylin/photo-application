
using Problème_scientifique___Image;

namespace Projet_S4
{
    class QRCode
    {
        const string alphanum = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ $%*+-./:";
        static byte nbCaracteres;
        string message;
        string recap;
        int tailleTotal;
        int[,] checkingForMask;
        int[,] debug;

        public string Message
        {
            get { return message; }

        }
        public string Recap
        {
            get { return recap; }

        }
        public int[,] CheckingForMask
        {
            get { return checkingForMask; }
        }
        public int[,] Debug
        {
            get { return debug; }
        }



        public QRCode(string message, string nom)
        {
            nbCaracteres = (byte)message.Length;
            this.message = message;
            recap = "0010" + QRCode.longueurMessageBinaire() + messageToBinary();
            if (nbCaracteres <= 25) //21x21
            {
                tailleTotal = 19 * 8;
                recap = Terminator();
                byte[] salomon = AvantSalomon();
                byte[] salomonfinal = ReedSolomonAlgorithm.Encode(salomon, 7, ErrorCorrectionCodeType.QRCode); //Application de Reed Salomon
                
                for (int i = 0; i < salomonfinal.Length; i++)
                {
                    string bin = Program.ByteToBinary(salomonfinal[i]);
                    bin = bin.PadLeft(8, '0');
                    recap += bin;
                }
                System.Console.WriteLine();
                
                MyImage QRCode = new MyImage(21, 21, nom, new Pixel(0, 0, 255));
                checkingForMask = new int[21, 21];
                debug = new int[21, 21];
                AddFinderPatterns(3, 3, QRCode.Matrice);
                AddFinderPatterns(QRCode.Hauteur - 4, 3, QRCode.Matrice);
                AddFinderPatterns(3, QRCode.Largeur - 4, QRCode.Matrice);

                AddSeparator(QRCode, QRCode.Matrice);

                AddTimingPattern(QRCode.Matrice);

                AddDarkModule(13, QRCode.Matrice);
                int cpt = 0;
                for (int j = QRCode.Largeur - 1; j > 9; j -= 4)
                {
                    cpt = UpwardPlacement(cpt, QRCode, j);
                    cpt = DownwardPlacement(cpt, QRCode, j - 2);
                }
                cpt = UpwardPlacement(cpt, QRCode, 8);
                cpt = DownwardPlacement(cpt, QRCode, 5);
                cpt = UpwardPlacement(cpt, QRCode, 3);
                cpt = DownwardPlacement(cpt, QRCode, 1);

                AddDataMask(QRCode);
                ApplyMask(QRCode);

                QRCode.MiroirVertical();
                QRCode.AgrandirImage(10);
                QRCode.From_Scratch_Image_To_File();


            }
            else if (nbCaracteres <= 47) //25x25
            {
                tailleTotal = 34 * 8;
                recap = Terminator();
                byte[] salomon = AvantSalomon();

                byte[] salomonfinal = ReedSolomonAlgorithm.Encode(salomon, 10, ErrorCorrectionCodeType.QRCode); //Application de Reed Salomon

                for (int i = 0; i < salomonfinal.Length; i++)
                {
                    string bin = Program.ByteToBinary(salomonfinal[i]);
                    bin = bin.PadLeft(8, '0');
                    recap += bin;
                }

                MyImage QRCode = new MyImage(25, 25, nom, new Pixel(0, 0, 255));
                checkingForMask = new int[25, 25];
                debug = new int[25, 25]; //A retirer
                AddFinderPatterns(3, 3, QRCode.Matrice);
                AddFinderPatterns(QRCode.Hauteur - 4, 3, QRCode.Matrice);
                AddFinderPatterns(3, QRCode.Largeur - 4, QRCode.Matrice);

                AddSeparator(QRCode, QRCode.Matrice);

                AddAlignmentPattern(18, 18, QRCode.Matrice);

                AddTimingPattern(QRCode.Matrice);

                AddDarkModule(17, QRCode.Matrice);

                int cpt = 0;
                for (int j = QRCode.Largeur - 1; j > 9; j -= 4)
                {
                    cpt = UpwardPlacement(cpt, QRCode, j);
                    cpt = DownwardPlacement(cpt, QRCode, j - 2);
                }
                cpt = UpwardPlacement(cpt, QRCode, 8);
                cpt = DownwardPlacement(cpt, QRCode, 5);
                cpt = UpwardPlacement(cpt, QRCode, 3);
                cpt = DownwardPlacement(cpt, QRCode, 1);
                AddDataMask(QRCode);
                ApplyMask(QRCode);

                QRCode.MiroirVertical();
                QRCode.AgrandirImage(10);
                QRCode.From_Scratch_Image_To_File();

            }
            else
            {
                System.Console.WriteLine("Impossible le message est trop long");
            }


        }

        public static string longueurMessageBinaire()
        {
            string b = Program.ByteToBinaryINT(nbCaracteres);
            b = b.PadLeft(9, '0');
            return b;
        }

        public string messageToBinary()
        {
            string messageBinaire = "";
            if (message.Length % 2 == 0)
            {
                for (int i = 0; i < message.Length - 1; i += 2)

                {
                    char lettre1 = message[i];
                    char lettre2 = message[i + 1];
                    int char1 = localiserLettre(lettre1);
                    int char2 = localiserLettre(lettre2);
                    string passage = Program.ByteToBinaryINT(45 * char1 + char2);
                    messageBinaire += " " + passage;

                }
            }
            else
            {
                for (int i = 0; i < message.Length - 2; i += 2)
                {
                    char lettre1 = message[i];
                    char lettre2 = message[i + 1];
                    int char1 = localiserLettre(lettre1);
                    int char2 = localiserLettre(lettre2);
                    //System.Console.WriteLine((45 * char1 + char2));
                    messageBinaire += Program.ByteToBinaryINT(45 * char1 + char2).PadLeft(11, '0');
                }
                int char3 = localiserLettre(message[message.Length - 1]);
                //System.Console.WriteLine(char3);
                messageBinaire += Program.ByteToBinaryINT(char3).PadLeft(6, '0');
            }
            return messageBinaire;


        }

        public int localiserLettre(char a)
        {
            for (int i = 0; i < alphanum.Length; i++)
            {
                if (a == alphanum[i])
                {
                    return i;
                }
                else
                {

                }
            }
            return -1;
        }

        public string Terminator()
        {
            if (recap.Length <= tailleTotal - 4)
            {
                recap = recap.PadRight(recap.Length + 4, '0');
                while (recap.Length % 8 != 0)
                {
                    recap += "0";
                }
                int pair = 0;
                while (recap.Length < tailleTotal)
                {
                    if (pair % 2 == 0)
                    {
                        recap += "11101100";
                    }
                    else
                    {
                        recap += "00010001";
                    }
                    pair++;
                }
            }
            else
            {
                recap = recap.PadRight(tailleTotal, '0');
                int pair = 0; //Pas nécessaire mais au cas ou 
                while (recap.Length < tailleTotal)
                {
                    if (pair % 2 == 0)
                    {
                        recap += "11101100";
                    }
                    else
                    {
                        recap += "00010001";
                    }
                    pair++;
                }
            }
            return recap;
        }

        public byte[] AvantSalomon()
        {
            byte[] tab = new byte[recap.Length / 8];
            int cpt = 0;
            for (int i = 0; i < recap.Length; i += 8)
            {
                int[] tabint = new int[8];
                for (int j = 0; j < 8; j++)
                {
                    tabint[j] = (int)System.Char.GetNumericValue(recap[i + j]);
                    //System.Console.WriteLine(tabint[j]);
                }
                //System.Console.WriteLine();
                tab[cpt] = Program.BinaryToByte(tabint);
                cpt++;
            }
            return tab;
        }

        public void AddFinderPatterns(int i, int j, Pixel[,] matrice)
        {
            for (int k = i - 3; k <= i + 3; k++)
            {
                for (int l = j - 3; l <= j + 3; l++)
                {
                    matrice[k, l] = new Pixel(0, 0, 0);
                    checkingForMask[k, l] = 1;
                }
            }
            matrice[i - 2, j - 2] = new Pixel(255, 255, 255);
            matrice[i - 2, j - 1] = new Pixel(255, 255, 255);
            matrice[i - 2, j] = new Pixel(255, 255, 255);
            matrice[i - 2, j + 1] = new Pixel(255, 255, 255);
            matrice[i - 2, j + 2] = new Pixel(255, 255, 255);

            matrice[i + 2, j - 2] = new Pixel(255, 255, 255);
            matrice[i + 2, j - 1] = new Pixel(255, 255, 255);
            matrice[i + 2, j] = new Pixel(255, 255, 255);
            matrice[i + 2, j + 1] = new Pixel(255, 255, 255);
            matrice[i + 2, j + 2] = new Pixel(255, 255, 255);

            matrice[i - 1, j - 2] = new Pixel(255, 255, 255);
            matrice[i, j - 2] = new Pixel(255, 255, 255);
            matrice[i + 1, j - 2] = new Pixel(255, 255, 255);

            matrice[i - 1, j + 2] = new Pixel(255, 255, 255);
            matrice[i, j + 2] = new Pixel(255, 255, 255);
            matrice[i + 1, j + 2] = new Pixel(255, 255, 255);
        }

        public void AddSeparator(MyImage qr, Pixel[,] matrice)
        {
            for (int i = 0; i < 8; i++)
            {
                checkingForMask[i, 7] = 1;
                checkingForMask[i, qr.Largeur - 8] = 1;
                checkingForMask[qr.Hauteur - 1 - i, 7] = 1;
                matrice[i, 7] = new Pixel(255, 255, 255);
                matrice[i, qr.Largeur - 8] = new Pixel(255, 255, 255);
                matrice[qr.Hauteur - 1 - i, 7] = new Pixel(255, 255, 255);

                checkingForMask[7, i] = 1;
                checkingForMask[qr.Hauteur - 8, i] = 1;
                checkingForMask[7, qr.Largeur - 1 - i] = 1;
                matrice[7, i] = new Pixel(255, 255, 255);
                matrice[qr.Hauteur - 8, i] = new Pixel(255, 255, 255);
                matrice[7, qr.Largeur - 1 - i] = new Pixel(255, 255, 255);
            }


        }

        public void AddAlignmentPattern(int i, int j, Pixel[,] matrice)
        {
            for (int k = i - 2; k <= i + 2; k++)
            {
                for (int l = j - 2; l <= j + 2; l++)
                {
                    checkingForMask[k, l] = 1;
                    matrice[k, l] = new Pixel(0, 0, 0);
                }
            }

            matrice[i - 1, j - 1] = new Pixel(255, 255, 255);
            matrice[i - 1, j] = new Pixel(255, 255, 255);
            matrice[i - 1, j + 1] = new Pixel(255, 255, 255);
            matrice[i + 1, j - 1] = new Pixel(255, 255, 255);
            matrice[i + 1, j] = new Pixel(255, 255, 255);
            matrice[i + 1, j + 1] = new Pixel(255, 255, 255);
            matrice[i, j - 1] = new Pixel(255, 255, 255);
            matrice[i, j + 1] = new Pixel(255, 255, 255);

        }

        public void AddTimingPattern(Pixel[,] matrice)
        {

            for (int j = 8; j < matrice.GetLength(1) - 8; j++)
            {
                checkingForMask[j, 6] = 1;
                checkingForMask[6, j] = 1;
                if (j % 2 == 0)
                {
                    matrice[j, 6] = new Pixel(0, 0, 0);
                    matrice[6, j] = new Pixel(0, 0, 0);
                }
                else
                {
                    matrice[j, 6] = new Pixel(255, 255, 255);
                    matrice[6, j] = new Pixel(255, 255, 255);
                }
            }
        }

        public void AddDarkModule(int x, Pixel[,] matrice)
        {
            matrice[x, 8] = new Pixel(0, 0, 0);
            checkingForMask[x, 8] = 1;

            for (int i = 0; i < 8; i++)
            {
                checkingForMask[i, 8] = 1;
                checkingForMask[8, i] = 1;
                checkingForMask[matrice.GetLength(0) - 1 - i, 8] = 1;
                checkingForMask[8, matrice.GetLength(1) - 1 - i] = 1;
                if (matrice[i, 8].Red == 255)
                {
                    matrice[i, 8] = new Pixel(255, 0, 0);
                }
                if (matrice[8, i].Red == 255)
                {
                    matrice[8, i] = new Pixel(255, 0, 0);
                }
                if (matrice[matrice.GetLength(0) - 1 - i, 8].Red == 255)
                {
                    matrice[matrice.GetLength(0) - 1 - i, 8] = new Pixel(255, 0, 0);
                }
                matrice[8, matrice.GetLength(1) - 1 - i] = new Pixel(255, 0, 0);

            }
            matrice[8, 8] = new Pixel(255, 0, 0);
            checkingForMask[8, 8] = 1;
        }

        public int UpwardPlacement(int cpt, MyImage QRCode, int j)
        {
            //cpt va parcourir la chaine recap

            for (int i = QRCode.Hauteur - 1; i >= 0; i--)
            {
                if (QRCode.Matrice[i, j].Red == 255 && QRCode.Matrice[i, j].Blue == 0 && cpt < recap.Length)
                {
                    if (recap[cpt] == '0')
                    {
                        QRCode.Matrice[i, j] = new Pixel(255, 255, 255);
                        debug[i, j] = 2; //A enlever
                    }
                    else
                    {
                        QRCode.Matrice[i, j] = new Pixel(0, 0, 0);
                        debug[i, j] = 1; //A enlever
                    }
                    cpt++;
                }
                else if (QRCode.Matrice[i, j].Red == 255 && QRCode.Matrice[i, j].Blue == 0 && cpt >= recap.Length)//peut etre remettre j-1aaa
                {
                    QRCode.Matrice[i, j] = new Pixel(255, 255, 255);
                    checkingForMask[i, j] = 1; //potentiellement à retirer
                }
                else
                {

                }

                if (QRCode.Matrice[i, j - 1].Red == 255 && QRCode.Matrice[i, j - 1].Blue == 0 && cpt < recap.Length)
                {
                    if (recap[cpt] == '0')
                    {
                        QRCode.Matrice[i, j - 1] = new Pixel(255, 255, 255);
                        debug[i, j - 1] = 2; //A enlever
                    }
                    else
                    {
                        QRCode.Matrice[i, j - 1] = new Pixel(0, 0, 0);
                        debug[i, j - 1] = 1; //A enlever
                    }
                    cpt++;
                }
                else if (QRCode.Matrice[i, j - 1].Red == 255 && QRCode.Matrice[i, j - 1].Blue == 0 && cpt >= recap.Length)
                {
                    QRCode.Matrice[i, j - 1] = new Pixel(255, 255, 255);
                    checkingForMask[i, j - 1] = 1;
                }
                else
                {

                }
                /*for (int m = 0; m < CheckingForMask.GetLength(0); m++) //Utile en cas de problème 
                {
                    for (int n = 0; n < CheckingForMask.GetLength(0); n++)
                    {
                        System.Console.Write(Debug[m, n] + " ");
                    }
                    System.Console.WriteLine();
                }
                System.Console.Write("\t" + cpt);
                System.Console.WriteLine();
                System.Console.ReadKey();
                System.Console.WriteLine();*/
            }
            return cpt;

        }

        public int DownwardPlacement(int cpt, MyImage QRCode, int j)
        {
            for (int i = 0; i < QRCode.Hauteur; i++)
            {
                if (QRCode.Matrice[i, j].Red == 255 && QRCode.Matrice[i, j].Blue == 0 && cpt < recap.Length)
                {
                    if (recap[cpt] == '0')
                    {
                        QRCode.Matrice[i, j] = new Pixel(255, 255, 255);
                        debug[i, j] = 2; //A enlever
                    }
                    else
                    {
                        QRCode.Matrice[i, j] = new Pixel(0, 0, 0);
                        debug[i, j] = 1; //A enlever
                    }
                    cpt++;
                }
                else if (QRCode.Matrice[i, j].Red == 255 && QRCode.Matrice[i, j].Blue == 0 && cpt >= recap.Length)
                {
                    QRCode.Matrice[i, j] = new Pixel(255, 255, 255);
                    checkingForMask[i, j] = 1;
                }
                else
                {

                }

                if (QRCode.Matrice[i, j - 1].Red == 255 && QRCode.Matrice[i, j - 1].Blue == 0 && cpt < recap.Length)
                {
                    if (recap[cpt] == '0')
                    {
                        QRCode.Matrice[i, j - 1] = new Pixel(255, 255, 255);
                        debug[i, j - 1] = 2; //A enlever
                    }
                    else
                    {
                        QRCode.Matrice[i, j - 1] = new Pixel(0, 0, 0);
                        debug[i, j - 1] = 1; //A enlever
                    }
                    cpt++;
                }
                else if (QRCode.Matrice[i, j - 1].Red == 255 && QRCode.Matrice[i, j - 1].Blue == 0 && cpt >= recap.Length)
                {
                    QRCode.Matrice[i, j - 1] = new Pixel(255, 255, 255);
                    checkingForMask[i, j - 1] = 1;
                }
                else
                {

                }
                /* for (int m = 0; m < CheckingForMask.GetLength(0); m++) //A enlever
                 {
                     for (int n = 0; n < CheckingForMask.GetLength(0); n++)
                     {
                         System.Console.Write(Debug[m,n] + " ");
                     }
                     System.Console.WriteLine();
                 }
                 System.Console.Write("\t" + cpt);
                 System.Console.WriteLine();
                 System.Console.ReadKey();
                 System.Console.WriteLine();
                */
            }
            return cpt;

        }

        public void AddDataMask(MyImage QRCode)
        {
            string data = "111011111000100";
            {
                int index = 0;
                for (int i = QRCode.Hauteur - 1; i >= 0; i--)
                {
                    if (QRCode.Matrice[i, 8].Red == 0 && QRCode.Matrice[i, 8].Blue == 255)
                    {
                        if (data[index] == '0')
                        {
                            QRCode.Matrice[i, 8] = new Pixel(255, 255, 255);
                        }
                        else
                        {
                            QRCode.Matrice[i, 8] = new Pixel(0, 0, 0);
                        }
                        index++;
                    }
                    else
                    {

                    }

                }
                index = 0;
                for (int j = 0; j < QRCode.Largeur; j++)
                {
                    if (QRCode.Matrice[8, j].Red == 0 && QRCode.Matrice[8, j].Blue == 255)
                    {
                        if (data[index] == '0')
                        {
                            QRCode.Matrice[8, j] = new Pixel(255, 255, 255);
                        }
                        else
                        {
                            QRCode.Matrice[8, j] = new Pixel(0, 0, 0);
                        }
                        index++;
                    }
                    else
                    {

                    }

                }
            }
        }

        public void ApplyMask(MyImage QRCode)
        {
            for (int i = 0; i < QRCode.Hauteur; i++)
            {
                for (int j = 0; j < QRCode.Largeur; j++)
                {
                    if (checkingForMask[i, j] == 0) //Vérifie si on doit appliquer le masque au pixel en quesiton
                    {
                        if ((i + j) % 2 == 0)
                        {
                            Pixel pix = new Pixel(0, 0, 0);
                            if ((pix.Red == 255 && QRCode.Matrice[i, j].Red == 255) || (pix.Red == 0 && QRCode.Matrice[i, j].Red == 0))
                            {
                                QRCode.Matrice[i, j] = new Pixel(255, 255, 255);
                            }
                            else
                            {
                                QRCode.Matrice[i, j] = new Pixel(0, 0, 0);
                            }
                        }
                        else
                        {
                            Pixel pix = new Pixel(255, 255, 255);
                            if ((pix.Red == 255 && QRCode.Matrice[i, j].Red == 255) || (pix.Red == 0 && QRCode.Matrice[i, j].Red == 0))
                            {
                                QRCode.Matrice[i, j] = new Pixel(255, 255, 255);
                            }
                            else
                            {
                                QRCode.Matrice[i, j] = new Pixel(0, 0, 0);
                            }
                        }
                    }
                    else
                    {

                    }
                }
            }
        }


    }

}





