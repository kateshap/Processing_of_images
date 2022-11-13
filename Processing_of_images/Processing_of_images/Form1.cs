using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Processing_of_images
{
    public partial class Form1 : Form
    {
        Bitmap originIm;
        Bitmap noiseIm;
        Bitmap afterNoiseIm;
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg; *.bmp | All Files (*.*)|*.* ";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                originIm = new Bitmap(dialog.FileName);
                pictureBox1.Image = originIm;
                pictureBox1.Refresh();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Save("C:\\Users\\shapo\\Desktop\\repos\\Processing_of_images\\Picture.bmp");
                    сохранитьToolStripMenuItem.Text = "Saved file.";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There was a problem saving the file." +
                    "Check the file permissions.");
            }
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Filter();
            /*Bitmap image = */originIm=filter.GrayScale(originIm);
            pictureBox1.Image = originIm;
            pictureBox1.Refresh();
        }

        private void AutocontrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Filter();
            Bitmap resultImage = filter.Autocontrast(originIm);
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }

        private void averageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Filter();
            Bitmap resultImage = filter.Average(originIm);
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }

        private void globalThresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Filter();
            Bitmap resultImage = filter.GlobalThreshold(originIm);
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }

        private void niblackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Filter();
            Bitmap resultImage = filter.Niblack(originIm);
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Filter();
            Bitmap resultImage = filter.HistogramThreshold(originIm);
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = originIm;
            pictureBox1.Refresh();
        }

        private void saltPepperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Filter();
            noiseIm = filter.NoiseSaltPepper(originIm);
            pictureBox1.Image = noiseIm;
            pictureBox1.Refresh();
        }

        private void uniformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Filter();
            noiseIm = filter.NoiseUniform(originIm);
            pictureBox1.Image = noiseIm;
            pictureBox1.Refresh();
        }

        private void gaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Filter();
            noiseIm = filter.GaussianNoise(originIm);
            pictureBox1.Image = noiseIm;
            pictureBox1.Refresh();
        }

        private void gammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Filter();
            noiseIm = filter.GammaNoise(originIm);
            pictureBox1.Image = noiseIm;
            pictureBox1.Refresh();
        }

        private void exponentialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Filter();
            noiseIm = filter.ExponentialNoise(originIm);
            pictureBox1.Image = noiseIm;
            pictureBox1.Refresh();
        }

        private void rayleighToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Filter();
            noiseIm = filter.RayleighNoise(originIm);
            pictureBox1.Image = noiseIm;
            pictureBox1.Refresh();
        }

        private void geometricToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Filter();
            afterNoiseIm = filter.GeometricMean(noiseIm);
            pictureBox2.Image = afterNoiseIm;
            pictureBox2.Refresh();
        }

        private void bilateralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Filter();
            afterNoiseIm = filter.Bilateral(noiseIm);
            pictureBox2.Image = afterNoiseIm;
            pictureBox2.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Filter filter = new Filter();
            label1.Text=filter.PSNR(originIm,afterNoiseIm).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Filter filter = new Filter();
            label2.Text = filter.SSIM(originIm, afterNoiseIm).ToString();
        }
    }
}
