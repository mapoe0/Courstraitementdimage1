using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Courstraitementdimage1
{
    public partial class Form1 : Form
    {
        Bitmap imagesrc;
        Bitmap imageDestination;
        Bitmap imageDestination2;
        int seuil = 127;
        int[] greyCount;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imagesrc = new Bitmap(@"C:\Users\polle\Downloads\lena.jpg");
            pbSource.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pbSource.Image = imagesrc;

        }

        private void BtnNoirEtBlanc_Click(object sender, EventArgs e)
        {
            imageDestination = new Bitmap(pbSource.Image.Width, pbSource.Image.Height);

            for (int x = 0; x < pbSource.Image.Width; x++)
            {
                for (int y = 0; y < pbSource.Image.Height; y++)
                {
                    Color pixelColor = imagesrc.GetPixel(x, y);

                    int grey = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    imageDestination.SetPixel(x, y, Color.FromArgb(grey, grey, grey));

                }
            }
            pictureBox1.Image = imageDestination;
        }

        private void btnBin_Click(object sender, EventArgs e)
        {
            imageDestination2 = new Bitmap(pbSource.Image.Width, pbSource.Image.Height);
            for (int x = 0; x < pbSource.Image.Width; x++)
            {
                for (int y = 0; y < pbSource.Image.Height; y++)
                {
                    Color pixelColor = imageDestination.GetPixel(x, y);
                    Color newColor;
                    if (pixelColor.R >= seuil)
                    {
                        newColor = Color.FromArgb(255, 255, 255);
                    }
                    else
                    {
                        newColor = Color.FromArgb(0, 0, 0);
                    }
                    imageDestination2.SetPixel(x, y, newColor);

                }
            }
            pictureBox2.Image = imageDestination2;
        }

        private void tbSeuil_Scroll(object sender, EventArgs e)
        {
            seuil = tbSeuil.Value;
            label1.Text = "seuil: " + seuil.ToString();
            btnBin.PerformClick();

        }

        private void negBtn_Click(object sender, EventArgs e)
        {
            imageDestination = new Bitmap(pbSource.Image.Width, pbSource.Image.Height);

            for (int x = 0; x < pbSource.Image.Width; x++)
            {
                for (int y = 0; y < pbSource.Image.Height; y++)
                {
                    Color pixelColor = imagesrc.GetPixel(x, y);

                    int r = 255 - pixelColor.R;
                    int b = 255 - pixelColor.B;
                    int g = 255 - pixelColor.G;

                    imageDestination.SetPixel(x, y, Color.FromArgb(r, g, b));

                }
            }
            pictureBox1.Image = imageDestination;
        }

        private void histogrameBtn_Click(object sender, EventArgs e)
        {

            greyCount = new int[256];
            for (int i = 0; i < greyCount.Length; i++)
            {
                greyCount[i] = 0;
            }
            greyCount = Histogramme(imageDestination, greyCount);
            DrawHistogram(greyCount);

        }
        private int[] Histogramme(Bitmap bitmap, int[] greyCount)
        {
            for (int x = 0; x < pbSource.Image.Width; x++)
            {
                for (int y = 0; y < pbSource.Image.Height; y++)
                {
                    greyCount[bitmap.GetPixel(x, y).R] += 1;                 
                }
            }
            int cpt = 0;
            int max = greyCount.Max();
            Console.WriteLine(max.ToString());
            for(int i = 0; i < greyCount.Length; i++)
            {
                greyCount[i] = (256 * greyCount[i]) / max;
                
                
            }
            Console.WriteLine(cpt.ToString());
            // mise à l'échelle: plus grande valeur = 256

            return greyCount;
        }
        public void DrawHistogram(int[] greyCount)
        {
            
            // int x1 y1;
            int y1, y2;            
            using (Graphics g = pictureBox2.CreateGraphics())
            {
                for (int i = 0; i < greyCount.Length; i++)
                {
                    
                    y1 = 255;
                    y2 = 255 - greyCount[i];
                    g.DrawLine(Pens.Black, new Point(i, y1), new Point(i, y2));
                }
                
            }
            
        }

        private void recadrage_Click(object sender, EventArgs e)
        {
            int seuilBas = 0;
            int seuilHaut = 0;
            // trouver les seuils
            for(int i = 0; i < greyCount.Length; i++)
            {
                //seuil bas
                if(greyCount[i] != 0 && seuilBas ==0)
                {
                    seuilBas = i;
                }

                // seuil haut
                if(greyCount[i]==0 && seuilHaut ==0 && seuilBas != 0)
                {
                    seuilHaut = i;
                }
            }

            
            Bitmap imageDestinationRecadre = new Bitmap(pbSource.Image.Width,pbSource.Image.Height);
            for (int x = 0; x < pbSource.Image.Width; x++)
            {
                for (int y = 0; y < pbSource.Image.Height; y++)
                {
                    Color pix = imageDestination.GetPixel(x, y);
                    int p = pix.R;
                    if(p>=seuilBas && p<= seuilHaut)
                    {
                        imageDestinationRecadre.SetPixel(x, y, Color.FromArgb(p, p, p));
                    }
                    
                }
            }
            pictureBox3.Image = imageDestinationRecadre;

            // on construit un nouvel histogramme
        }
    }
}



