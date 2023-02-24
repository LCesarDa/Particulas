using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParticulasImagen
{
    public partial class Form1 : Form
    {
        Bitmap canva;
        Graphics g;
        PictureBox pictureBox;
        int w = 535, h = 724;
        PointF emiter;
        List<Part> parts = new List<Part>();
        bool open = true;
        int c = 0, d;
        Image[] drop = new Image[7]
        {
            Resource1.Gota,
            Resource1.Gota1,
            Resource1.Gota2,
            Resource1.Gota3,
            Resource1.Gota4,
            Resource1.Gota5,
            Resource1.Gota6
        };
        static Random rand = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.DrawImage(Resource1.regadera, 0, 0, 575, 800);
            if (c < parts.Count) c++;
            for (int i = 0; i < c; i++)
            {
                parts[i].Update(emiter, open);
                if (open)
                {
                    g.DrawImage(drop[rand.Next(0,6)], parts[i].pos.X, parts[i].pos.Y, parts[i].rad, parts[i].rad);
                } else
                {
                    if(parts[i].pos.X < emiter.X+d)
                    {
                        g.DrawImage(drop[rand.Next(0, 6)], parts[i].pos.X, parts[i].pos.Y, parts[i].rad, parts[i].rad);
                    }
                }
            }
            if (d>40)d-=20;
            pictureBox.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            open = !open;
            c = 0;
            d = w - (int)emiter.X;
        }

        public Form1()
        {
            InitializeComponent();
            canva = new Bitmap(w, h);
            g = Graphics.FromImage(canva);
            emiter = new PointF(160, 160);
            pictureBox = new PictureBox
            {
                Image = canva,
                Size = new Size(w, h),
                Location = new Point(0, 0),
                BackColor = Color.Transparent
            };
            for (int i = 0; i < 100; i++)
            {
                parts.Add(new Part(pictureBox.Size, emiter));
            }
            this.Controls.Add(pictureBox);
        }

    }
}
