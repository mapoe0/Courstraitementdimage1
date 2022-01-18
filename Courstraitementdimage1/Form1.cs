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
            imagesrc = new Bitmap(@"C:\HEI4IMS\CLASSE1.jpg");
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
            pictureBox2.Image = null;
            pictureBox2.Update();
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
                    byte red;
                    red = pix.R;
                    red = (byte)(255 * (red - seuilBas) / (seuilHaut - seuilBas));

                    Color newpix = Color.FromArgb(255, red, red, red);
                    imageDestinationRecadre.SetPixel(x, y, newpix);
                }
            }
            pictureBox3.Image = imageDestinationRecadre;
            for(int i = 0; i < 256; i++)
            {
                greyCount[i] = 0;
            }
            greyCount = Histogramme(imageDestinationRecadre, greyCount);
            DrawHistogram(greyCount);

            // on construit un nouvel histogramme
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int filtre = listBox1.SelectedIndex;
            switch (filtre)
            {
                case 0:
                    filtreMoyenneur();
                    break;
                case 1:
                    filtrepassbas();
                    break;
                case 2:
                    filtrepasseHaut();
                    break;
                case 3:
                    filtreLaplacien();
                    break;
                case 4:
                    filtreGradient();
                    break;
            }
        }
        
        private void filtreGradient()
        {
            Bitmap bit = new Bitmap(pbSource.Image.Width, pbSource.Image.Height);
            int[,] mat = new int[3, 3] { { -1, -1, -1 }, { 1, 1, 1 }, { 0, 0, 0 } };

            for (int x = 1; x < (pbSource.Image.Width - 1); x++)
            {
                for (int y = 1; y < (pbSource.Image.Height - 1); y++)
                {
                    int gris = 0;
                    for (int k = -1; k < 2; k++)
                    {
                        for (int n = -1; n < 2; n++)
                        {
                            Color pix = imageDestination.GetPixel(x + k, y + n);
                            int r = pix.R;
                            r = r * mat[k + 1, n + 1];
                            gris += r;
                        }
                    }
                    if (gris < 0)
                    {
                        gris = 0;
                    }
                    else if (gris > 255)
                    {
                        gris = 255;
                    }
                    Color newColor = Color.FromArgb(gris, gris, gris);
                    bit.SetPixel(x, y, newColor);
                }

            }
            pictureBox4.Image = bit;
        }
        private void filtreLaplacien()
        {
            Bitmap bit = new Bitmap(pbSource.Image.Width, pbSource.Image.Height);
            int[,] mat = new int[3, 3] { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } };

            for (int x = 1; x < (pbSource.Image.Width - 1); x++)
            {
                for (int y = 1; y < (pbSource.Image.Height - 1); y++)
                {
                    int gris = 0;
                    for (int k = -1; k < 2; k++)
                    {
                        for (int n = -1; n < 2; n++)
                        {
                            Color pix = imageDestination.GetPixel(x + k, y + n);
                            int r = pix.R;
                            r = r * mat[k + 1, n + 1];
                            gris += r;
                        }
                    }
                    if (gris < 0)
                    {
                        gris = 0;
                    }
                    else if (gris > 255)
                    {
                        gris = 255;
                    }
                    Color newColor = Color.FromArgb(gris, gris, gris);
                    bit.SetPixel(x, y, newColor);
                }

            }
            pictureBox4.Image = bit;
        }
        private void filtrepasseHaut()
        {
            Bitmap bit = new Bitmap(pbSource.Image.Width, pbSource.Image.Height);
            int[,] mat = new int[3, 3] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };

            for (int x = 1; x < (pbSource.Image.Width - 1); x++)
            {
                for (int y = 1; y < (pbSource.Image.Height - 1); y++)
                {
                    int gris = 0;
                    for (int k = -1; k < 2; k++)
                    {
                        for (int n = -1; n < 2; n++)
                        {
                            Color pix = imageDestination.GetPixel(x + k, y + n);
                            int r = pix.R;
                            r = r * mat[k + 1, n + 1];
                            gris += r;
                        }
                    }
                    if (gris < 0)
                    {
                        gris = 0;
                    }
                    else if (gris > 255)
                    {
                        gris = 255;
                    }
                    Color newColor = Color.FromArgb(gris, gris, gris);
                    bit.SetPixel(x, y, newColor);
                }

            }
            pictureBox4.Image = bit;
        }
        private void filtrepassbas()
        {
            Bitmap bit = new Bitmap(pbSource.Image.Width, pbSource.Image.Height);
            int[,] mat = new int[3, 3] { { 1, 1, 1 }, { 1, 4, 1 }, { 1, 1, 1 } };
            for (int x = 1; x < (pbSource.Image.Width - 1); x++)
            {
                for (int y = 1; y < (pbSource.Image.Height - 1); y++)
                {
                    int gris = 0;
                    for (int k = -1; k < 2; k++)
                    {
                        for (int n = -1; n < 2; n++)
                        {
                            Color pix = imageDestination.GetPixel(x + k, y + n);
                            int r = pix.R;
                            r = r * mat[k + 1, n + 1];

                            gris += r;
                        }
                    }
                    gris = gris / 12;
                    Color newColor = Color.FromArgb(gris, gris, gris);
                    bit.SetPixel(x, y, newColor);
                }

            }
            pictureBox4.Image = bit;
        }
        private void filtreMoyenneur()
        {
            Bitmap bit = new Bitmap(pbSource.Image.Width, pbSource.Image.Height);

            for (int x = 1; x < (pbSource.Image.Width - 1); x++)
            {
                for (int y = 1; y < (pbSource.Image.Height - 1); y++)
                {
                    int gris = 0;
                    for (int k = -1; k < 2; k++)
                    {
                        for (int n = -1; n < 2; n++)
                        {
                            Color pix = imageDestination.GetPixel(x + k, y + n);
                            gris += pix.R;
                        }
                    }
                    gris = gris / 9;
                    Color newColor = Color.FromArgb(gris, gris, gris);
                    bit.SetPixel(x, y, newColor);
                }

            }
            pictureBox4.Image = bit;
        }

        private void Erosion()
        {
            Bitmap bit = new Bitmap(pbSource.Image.Width, pbSource.Image.Height);
            int fond = 0;

            for (int x = 1; x < (pbSource.Image.Width - 1); x++)
            {
                for (int y = 1; y < (pbSource.Image.Height - 1); y++)
                {
                    int gris = imageDestination2.GetPixel(x, y).R;
                    bool test = false;
                    for (int k = -1; k < 2; k++)
                    {
                        if (!test)
                        {
                            for (int n = -1; n < 2; n++)
                            {
                                int pix = imageDestination2.GetPixel(x + k, y + n).R;
                                if (pix == fond)
                                {
                                    gris = 0;
                                    test = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    Color newColor = Color.FromArgb(gris, gris, gris);
                    bit.SetPixel(x, y, newColor);
                }

            }
            pictureBox4.Image = bit;
        }
        private void Dilatation()
        {   
            Bitmap bit = new Bitmap(pbSource.Image.Width, pbSource.Image.Height);
            Bitmap pb = imageDestination2;
            if(pictureBox4.Image != null)
            {
                pb = new Bitmap(pictureBox4.Image);
            }
            int fond = 255;

            for (int x = 1; x < (pbSource.Image.Width - 1); x++)
            {
                for (int y = 1; y < (pbSource.Image.Height - 1); y++)
                {
                    int gris = pb.GetPixel(x, y).R;
                    bool test = false;
                    for (int k = -1; k < 2; k++)
                    {
                        if (!test)
                        {
                            for (int n = -1; n < 2; n++)
                            {
                                int pix = pb.GetPixel(x + k, y + n).R;
                                if (pix == fond)
                                {
                                    gris = 255;
                                    test = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    Color newColor = Color.FromArgb(gris, gris, gris);
                    bit.SetPixel(x, y, newColor);
                }

            }
            pictureBox4.Image = bit;
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox2.SelectedIndex;
            switch (index)
            {
                case 0:
                    Erosion();
                    break;
                case 1:
                    Dilatation();
                    break;
            }
        }
    }
}




