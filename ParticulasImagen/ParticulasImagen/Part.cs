using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticulasImagen
{
    public class Part
    {
        public int rad;
        public PointF pos, posi, vi, va;
        static Random rand = new Random();
        int lt;
        Size box;

        public Part(Size b, PointF e)
        {
            box = b;
            rad = rand.Next(5, 50);
            posi = e;
            pos = e;
            vi = new PointF(1, rand.Next(1, 5));
            va = vi;
            lt = rand.Next(5, 100);
        }

        public void wall()
        {
            if (pos.X - rad < 0 || pos.X + rad > 535)
            {
                va = vi;
                pos = posi;
            }

            if (pos.Y - rad < 0 || pos.Y + rad > 724)
            {
                va = vi;
                pos = posi;
            }
        }
        public void Update(PointF e, bool c)
        {
            if (c) { 
                posi = e;
                va.X += rand.Next(1, 3);
                va.Y += rand.Next(1, 7);
                pos.X += va.X;
                pos.Y += va.Y;
                wall();
                lt--;
                if (lt == 0)
                {
                    va = vi;
                    pos = posi;
                }
            } else { 
                posi = new PointF (800,800);
                va.X += 0;
                va.Y += 1;
                pos.Y += va.Y;
                wall();
                lt--;
                if (lt == 0)
                {
                    va = vi;
                    pos = posi;
                }

            }
            
        }


    }
}
