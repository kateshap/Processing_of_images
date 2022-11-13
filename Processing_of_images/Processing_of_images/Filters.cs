using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Syncfusion.XlsIO;
using System.IO;


namespace Processing_of_images
{
    public class Filter
    {
        int _maxR, _maxG, _maxB = 0;
        int _minR, _minG, _minB = 255;


        public int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        public int Bord(int value, int max)
        {
            if (value > max)
                return value - 255;
            return value;
        }
        protected Color NewGrayScalePixel(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int intensity = (int)(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);
            Color resultColor = Color.FromArgb(intensity,
                                                intensity,
                                                intensity);
            return resultColor;
        }

        public Bitmap GrayScale(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, NewGrayScalePixel(sourceImage, i, j));
                }
            }
            return resultImage;
        }

        protected void Brightness(Bitmap sourceImage)
        {
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color sourceColor = sourceImage.GetPixel(i, j);
                    int brightness = (int)(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);
                    /*if (brightness > MaxBright)
                        MaxBright = brightness;
                    if (brightness < MinBright)
                        MinBright = brightness;*/
                    //return brightness;
                }
            }

        }

        public Color NewAveragePixel(Bitmap sourceImage, int x, int y)
        {
            int avgR = 0, avgG = 0, avgB = 0;
            int radiusX = 1, radiusY = 1;
            int avgArith = (int)Math.Pow(radiusX * 2 + 1, 2);

            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {

                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);

                    avgR += neighborColor.R;
                    avgG += neighborColor.G;
                    avgB += neighborColor.B;
                }
            }
            return Color.FromArgb(Clamp((int)avgR / avgArith, 0, 255),
                                    Clamp((int)avgG / avgArith, 0, 255),
                                    Clamp((int)avgB / avgArith, 0, 255));
        }

        public Bitmap Average(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, NewAveragePixel(sourceImage, i, j));
                }
            }
            return resultImage;
        }

        protected void MaxMinCanal(Bitmap sourceImage)
        {
            _maxR = 0;
            _maxG = 0;
            _maxB = 0;
            _minR = 255;
            _minG = 255;
            _minB = 255;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color sourceColor = sourceImage.GetPixel(i, j);
                    if (sourceColor.R > _maxR)
                        _maxR = sourceColor.R;
                    else if (sourceColor.G > _maxG)
                        _maxG = sourceColor.G;
                    else if (sourceColor.B > _maxB)
                        _maxB = sourceColor.B;
                    else if (sourceColor.R < _minR)
                        _minR = sourceColor.R;
                    else if (sourceColor.G < _minG)
                        _minG = sourceColor.G;
                    else if (sourceColor.B < _minB)
                        _minB = sourceColor.B;
                }
            }

        }
        protected Color NewAutocontrastPixel(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int resR = (sourceColor.R - _minR) * 255 / (_maxR - _minR);
            int resG = (sourceColor.G - _minG) * 255 / (_maxG - _minG);
            int resB = (sourceColor.B - _minB) * 255 / (_maxB - _minB);
            Color resultColor = Color.FromArgb(Clamp(resR, 0, 255),
                                                Clamp(resG, 0, 255),
                                                Clamp(resB, 0, 255));
            return resultColor;
        }
        public Bitmap Autocontrast(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            MaxMinCanal(sourceImage);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, NewAutocontrastPixel(sourceImage, i, j));
                }
            }
            return resultImage;
        }

        protected Color NewGlobalThresholdPixel(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor;
            if (sourceColor.R > 127)
                resultColor = Color.FromArgb(255, 255, 255);
            else
                resultColor = Color.FromArgb(0, 0, 0);
            return resultColor;
        }
        public Bitmap GlobalThreshold(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, NewGlobalThresholdPixel(sourceImage, i, j));
                }
            }
            return resultImage;
        }

        public Color NewNiblackPixel(Bitmap sourceImage, int x, int y)
        {
            double avgSum = 0, standardDev = 0, avgStandardDev = 0, k = -0.2;
            int sum = 0, threshold = 0;
            int w = 5;
            int sqCount = (int)Math.Pow(w * 2 + 1, 2);

            for (int l = -w; l <= w; l++)
            {
                for (int m = -w; m <= w; m++)
                {

                    int idX = Clamp(x + m, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    sum += neighborColor.R;
                }
            }
            avgSum = sum / sqCount;
            for (int l = -w; l <= w; l++)
            {
                for (int m = -w; m <= w; m++)
                {
                    int idX = Clamp(x + m, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    standardDev += Math.Pow(neighborColor.R - avgSum, 2);
                }
            }
            avgStandardDev = Math.Sqrt(standardDev / sqCount);
            threshold = (int)(avgStandardDev * k + avgSum);
            if (sourceImage.GetPixel(x, y).R > threshold)
                return Color.FromArgb(255, 255, 255);
            else
                return Color.FromArgb(0, 0, 0);
        }


        public Bitmap Niblack(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, NewNiblackPixel(sourceImage, i, j));
                }
            }
            return resultImage;
        }

        protected void Histogram(Bitmap sourceImage, int[] hist)
        {
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    hist[sourceImage.GetPixel(i, j).R]++;
                }
            }
        }
        protected Color NewHistogramThresholdPixel(Bitmap sourceImage, int x, int y, int Threshold)
        {
            if (sourceImage.GetPixel(x, y).R > Threshold)
                return Color.FromArgb(255, 255, 255);
            else
                return Color.FromArgb(0, 0, 0);
        }
        public Bitmap HistogramThreshold(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            int[] hist = new int[256];
            int countColor = 0;
            Histogram(sourceImage, hist);
            for (int i = 0; i < hist.Length; i++)
                if (hist[i] != 0)
                    countColor++;

            int present = (int)(hist.Sum() * 0.05);
            int k = 0;
            int m = 0;
            while (k < present)
            {
                if (hist[m] == 0)
                {
                    continue;
                }

                k += hist[m];
                hist[m] = 0;
                m++;
            }

            m = 255;
            k = 0;
            while (k < present)
            {
                if (hist[m] == 0)
                {
                    continue;
                }

                k += hist[m];
                hist[m] = 0;
                m--;
            }

            int num = 0, den = 0;
            for (int i = 0; i < hist.Length; i++)
            {
                num += hist[i] * i;
                den += hist[i];
            }

            int t = num / den;

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, NewHistogramThresholdPixel(sourceImage, i, j, t));
                }
            }

            return resultImage;
        }

        public Bitmap NoiseUniform(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Random rand = new Random();
            int a = 0, b = 30;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    int tmp = rand.Next(a, b);
                    int res = Clamp(sourceImage.GetPixel(i, j).R + tmp, 0, 255);
                    resultImage.SetPixel(i, j, Color.FromArgb(res, res, res));
                }
            }
            return resultImage;
        }

        public Bitmap GaussianNoise(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Random rand = new Random();
            double mu = 0, sigma = 20, sum = 0;
            int size = 100, count = 0 ;
            double[] intensity = new double[size];
            byte[] noise = new byte[sourceImage.Width * sourceImage.Height];
            
            for (int i = 0; i < intensity.Length; i++)
            {
                intensity[i] = (1 / (Math.Sqrt(2 * Math.PI * sigma))) * Math.Exp(-Math.Pow(i - mu, 2) / (2 * Math.Pow(sigma, 2)));
                sum += intensity[i];               
            }

            for (int i = 0; i < intensity.Length; i++)
            {
                intensity[i] /= sum;
                intensity[i] *= noise.Length;
                intensity[i] = (int)intensity[i];
            }
            ArrToExcel(intensity, "C:/Users/shapo/Desktop/repos/Processing_of_images/SaltPepperNoise.xlsx");

            for (int i = 0; i < intensity.Length; i++)
            {
                for (int j = 0; j < intensity[i]; j++)
                {
                    noise[count + j] = (byte)i;
                }
                count += (int)intensity[i];
            }

            noise = noise.OrderBy(x => rand.Next()).ToArray();
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    int res = Clamp(sourceImage.GetPixel(i, j).R + noise[sourceImage.Height * i + j], 0, 255);
                    resultImage.SetPixel(i, j, Color.FromArgb(res, res, res));
                }
            }
            return resultImage;
        }      

        public Bitmap ExponentialNoise(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Random rand = new Random();
            double a = 0.05, sum = 0;
            int count = 0;
            double[] intensity = new double[256];
            byte[] noise = new byte[sourceImage.Width * sourceImage.Height];

            for (int i = 0; i < intensity.Length; i++)
            {
                intensity[i] = a * Math.Exp(-a * i);
                sum += intensity[i];
            }

            for (int i = 0; i < intensity.Length; i++)
            {
                intensity[i] /= sum;
                intensity[i] *= noise.Length;
                intensity[i] = (int)intensity[i];
            }
            for (int i = 0; i < intensity.Length; i++)
            {
                for (int j = 0; j < intensity[i]; j++)
                {
                    noise[count + j] = (byte)i;
                }
                count += (int)intensity[i];
            }

            noise = noise.OrderBy(x => rand.Next()).ToArray();
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    int res = Clamp(sourceImage.GetPixel(i, j).R + noise[sourceImage.Height * i + j], 0, 255);
                    resultImage.SetPixel(i, j, Color.FromArgb(res, res, res));
                }
            }
            return resultImage;
        }

        public Bitmap RayleighNoise(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Random rand = new Random();
            double a = 0,b = 400, sum = 0;
            int count = 0;
            double[] intensity = new double[256];
            byte[] noise = new byte[sourceImage.Width * sourceImage.Height];

            for (int i = 0; i < intensity.Length; i++)
            {
                intensity[i] = (2 / b) * (i - a) * Math.Exp(-Math.Pow(i - a, 2) / b);
                sum += intensity[i];
            }

            for (int i = 0; i < intensity.Length; i++)
            {
                intensity[i] /= sum;
                intensity[i] *= noise.Length;
                intensity[i] = (int)intensity[i];
            }
            for (int i = 0; i < intensity.Length; i++)
            {
                for (int j = 0; j < intensity[i]; j++)
                {
                    noise[count + j] = (byte)i;
                }
                count += (int)intensity[i];
            }

            noise = noise.OrderBy(x => rand.Next()).ToArray();
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    int res = Clamp(sourceImage.GetPixel(i, j).R + noise[sourceImage.Height * i + j], 0, 255);
                    resultImage.SetPixel(i, j, Color.FromArgb(res, res, res));
                }
            }
            return resultImage;
        }

        public Bitmap NoiseSaltPepper(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Random rand = new Random();
            double[] noise = new double[256];
            int max = 100;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    int tmp = rand.Next(max + 1);
                    if (tmp == 0)
                    {
                        noise[0]++;
                        resultImage.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }

                    else if (tmp == max)
                    {
                        noise[255]++;
                        resultImage.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        resultImage.SetPixel(i, j, sourceImage.GetPixel(i, j));
                    }

                }
            }
            ArrToExcel(noise, "C:/Users/shapo/Desktop/repos/Processing_of_images/SaltPepperNoise.xlsx");
            return resultImage;
        }

        int Factorial(int n)
        {
            if (n == 1) return 1;

            return n * Factorial(n - 1);
        }

        public Bitmap GammaNoise(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Random rand = new Random();
            double a = 0.3, sum = 0; ;
            int b = 3, size = 100, count = 0;
            double[] intensity = new double[size];
            byte[] noise = new byte[sourceImage.Width * sourceImage.Height];
            
            for (int i = 0; i < intensity.Length; i++)
            {
                intensity[i] = Math.Exp(-a * i) * Math.Pow(a, b) * Math.Pow(i, b - 1)/ Factorial(b - 1);
                sum += intensity[i];
            }

            for (int i = 0; i < intensity.Length; i++)
            {
                intensity[i] /= sum;
                intensity[i] *= noise.Length;
                intensity[i] = (int)intensity[i];
            }
            ArrToExcel(intensity, "C:/Users/shapo/Desktop/repos/Processing_of_images/GammaNoise.xlsx");
            for (int i = 0; i < intensity.Length; i++)
            {
                for (int j = 0; j < intensity[i]; j++)
                {
                    noise[count + j] = (byte)i;
                }
                count += (int)intensity[i];
            }

            for (int i = noise.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i);
                byte temp = noise[j];
                noise[j] = noise[i];
                noise[i] = temp;
            }

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    int res = Clamp(sourceImage.GetPixel(i, j).R + noise[sourceImage.Height * i + j], 0, 255);
                    resultImage.SetPixel(i, j, Color.FromArgb(res, res, res));
                }
            }
            return resultImage;
        }

        public Color NewGeometricMeanPixel(Bitmap sourceImage, int x, int y)
        {
            double avg= 1;
            int radius = 1;
            double degree = 1/Math.Pow(radius * 2 + 1, 2);

            for (int l = -radius; l <= radius; l++)
            {
                for (int k = -radius; k <= radius; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    avg *= neighborColor.R;
                }
            }
            return Color.FromArgb(Clamp((int)Math.Pow(avg,degree), 0, 255),
                                    Clamp((int)Math.Pow(avg, degree), 0, 255),
                                    Clamp((int)Math.Pow(avg, degree), 0, 255));
        }

        public Bitmap GeometricMean(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, NewGeometricMeanPixel(sourceImage, i, j));
                }
            }
            return resultImage;
        }

        public Color NewBilateralPixel(Bitmap sourceImage, int x, int y)
        {
            double sigma = 10;
            double sum = 0, sumGaus = 0, gaussian1, gaussian2;
            int radius = 1;

            for (int l = -radius; l <= radius; l++)
            {
                for (int k = -radius; k <= radius; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);

                    gaussian1 = 1 / (2 * Math.PI * Math.Pow(sigma, 2)) * Math.Exp(-(Math.Pow(l, 2) + Math.Pow(k, 2)) / (2 * Math.Pow(sigma, 2)));
                    gaussian2 = 1 / (Math.Sqrt(2*Math.PI)*sigma) * Math.Exp(-(Math.Pow((double)neighborColor.R/255- (double)sourceImage.GetPixel(x, y).R/255, 2)) / (2 * Math.Pow(sigma,2)));
                    sumGaus += gaussian1 * gaussian2;
                    sum += gaussian1 * gaussian2 * (double)neighborColor.R/255;
                    
                }
            }
            return Color.FromArgb(Clamp((int)(sum / sumGaus*255), 0, 255),
                                    Clamp((int)(sum / sumGaus*255), 0, 255),
                                    Clamp((int)(sum / sumGaus*255), 0, 255));
        }

        public Bitmap Bilateral(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, NewBilateralPixel(sourceImage, i, j));
                }
            }
            return resultImage;
        }

        public int PSNR(Bitmap sourceImage1, Bitmap sourceImage2)
        {
            double sum = 0, MSE;
            int PSNR;
            for (int i = 0; i < sourceImage1.Width; i++)
            {
                for (int j = 0; j < sourceImage1.Height; j++)
                {
                    sum += Math.Pow(sourceImage1.GetPixel(i, j).R - sourceImage2.GetPixel(i, j).R, 2);
                }
            }
            MSE = sum / sourceImage1.Width / sourceImage1.Height;
            PSNR = (int)(20 * Math.Log10(255 / Math.Sqrt(MSE)));
            return PSNR;
        }

        public double ArithMean(Bitmap sourceImage, int x, int y)
        {
            int radius = 3;
            int count = (int)Math.Pow(radius * 2 + 1, 2);
            double sum = 0;
            for (int l = -radius; l <= radius; l++)
            {
                for (int k = -radius; k <= radius; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);

                    sum += neighborColor.R;
                }
            }
            return sum / count;
        }
        public double MeanSquareDeviation(Bitmap sourceImage, int x, int y,double s)
        {
            int radius = 3;
            int count = (int)Math.Pow(radius * 2 + 1, 2);
            double sum = 0;

            for (int l = -radius; l <= radius; l++)
            {
                for (int k = -radius; k <= radius; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);

                    sum += Math.Pow(neighborColor.R-s,2);
                }
            }
            return Math.Sqrt(sum /count);
        }

        public double MeanSquareDeviationDouble(Bitmap sourceImage1,Bitmap sourceImage2, int x, int y, double s1,double s2)
        {
            int radius = 3;
            int count = (int)Math.Pow(radius * 2 + 1, 2);
            double sum = 0;
            for (int l = -radius; l <= radius; l++)
            {
                for (int k = -radius; k <= radius; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage1.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage1.Height - 1);
                    Color neighborColor1 = sourceImage1.GetPixel(idX, idY);
                    Color neighborColor2 = sourceImage2.GetPixel(idX, idY);
                    
                    sum += (neighborColor1.R - s1)*(neighborColor2.R - s2);
                }
            }           
            return sum /count;
        }

        public double SSIM(Bitmap sourceImage1, Bitmap sourceImage2)
        {
            double l, c, s;
            double mX, mY, sigmaX, sigmaY,sigmaXY;
            double SSIM = 0;
            double c1 = 6.5025, c2 = 58.5252, c3 = 29.26125;
            for (int i = 0; i < sourceImage1.Width; i++)
            {
                for (int j = 0; j < sourceImage1.Height; j++)
                {
                    mX = ArithMean(sourceImage1, i, j);
                    mY = ArithMean(sourceImage2, i, j);
                    sigmaX = MeanSquareDeviation(sourceImage1, i, j, mX);
                    sigmaY = MeanSquareDeviation(sourceImage2, i, j, mY);
                    sigmaXY = MeanSquareDeviationDouble(sourceImage1, sourceImage2, i, j, mX, mY);
                    l = (2 * mX * mY + c1) / (mX * mX + mY * mY + c1);
                    c = (2 * sigmaX * sigmaY + c2) / (sigmaX * sigmaX + sigmaY * sigmaY + c2);
                    s = (sigmaXY + c3) / (sigmaX * sigmaY + c3);
                    SSIM += l * c * s;
                }
            }      
            return SSIM/ sourceImage1.Width/ sourceImage1.Height;
        }

        public void ArrToExcel(double[] arr,string path)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2016;
            
            IWorkbook workbook = application.Workbooks.Create(1);
            IWorksheet sheet = workbook.Worksheets[0];
            sheet.ImportArray(arr, 1, 1, false);

            Stream excelStream = File.Create(path);
            workbook.SaveAs(excelStream);
            excelStream.Dispose();
        }
    }
}

