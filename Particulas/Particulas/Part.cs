using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Particulas
{
    public class Part
    {
        public int rad;
        public Color col;
        public PointF pos, posi, vi, va;
        static Random rand = new Random();
        int lt;
        Size box;

        public Part(Size b, PointF e) 
        {
            box = b;
            rad = rand.Next(3, 10);
            posi = e;
            pos = e;
            vi  = new PointF(1,rand.Next(-50,-5));
            va = vi;
            col = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
            lt = rand.Next(5, 100);
        }

        public void wall()
        {
            if (pos.X - rad < 0 || pos.X + rad > box.Width)
            {
                va = vi;
                pos = posi;
            }

            if (pos.Y - rad < 0 || pos.Y + rad > box.Height)
            {
                va = vi;
                pos = posi;
            }
        }
        public void Update(PointF e)
        {
            posi = e;
            va.X += rand.Next(1, 10);
            va.Y += rand.Next(1, 10);
            pos.X += va.X;
            pos.Y += va.Y;
            wall();
            lt--;
            if(lt == 0)
            {
                va = vi;
                pos = posi;
            }
        }


    }
}
