using System;

namespace Projet_S4
{
    class Bruit
    {
        public double GenererBruit(double x, double y, int a, int b, int c)
        {

            return (a * x * (-y) + b * x + c * y + c * (-x * x) + a * y * y - y * a * b + x * x);
            
        }

        

        public Pixel ApplicationCouleur(double height)
        {
            Pixel pix;
            if (height < 0.30)
            {
                pix = new Pixel(166, 72, 27);
            }
            else if (height < 0.38)
            {
                pix = new Pixel(255, 164, 0);
            }
            else if (height < 0.4)
            {
                pix = new Pixel(255, 242, 112);
            }
            else if (height < 0.45)
            {
                pix = new Pixel( 0,255,255 );
            }
            else if (height < 0.55)
            {
                pix = new Pixel( 48, 185,76 );
            }
            else if (height < 0.60)
            {
                pix = new Pixel( 48, 130, 20);
            }
            else if (height < 0.7)
            {
                pix = new Pixel( 27,66 ,99 );
            }
            else if (height < 0.9)
            {
                pix = new Pixel( 19, 45, 67);
            }
            else
            {
                pix = new Pixel(255, 255, 255);
            }
            return pix;

        }
    }
}
