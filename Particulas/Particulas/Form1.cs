using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Particulas
{
    public partial class Form1 : Form
    {
        Bitmap canva;
        Graphics g;
        PictureBox pictureBox;
        int w = 800, h = 800;
        PointF emiter;
        List<Part> parts = new List<Part>();

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.Black);

            for (int i = 0; i < parts.Count; i++)
            {
                parts[i].Update(emiter);
                g.FillEllipse(new SolidBrush(parts[i].col), parts[i].pos.X, parts[i].pos.Y, parts[i].rad, parts[i].rad);
            }

            pictureBox.Refresh();
        }

        public Form1()
        {
            InitializeComponent();
            canva = new Bitmap(w, h);
            g = Graphics.FromImage(canva);
            emiter = new PointF(100, 100);
            pictureBox = new PictureBox
            {
                Image = canva,
                Size = new Size(w, h),
                Location = new Point(0, 0),
                BackColor = Color.Black
            };
            for (int i = 0; i < 1000; i++)
            {
                parts.Add(new Part(pictureBox.Size, emiter));
            }
            this.Controls.Add(pictureBox);
        }

    }
}
