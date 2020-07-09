using System;
using System.Drawing;
using System.Text;

namespace CD252
{
    class Program
    {

        static void Main()
        {
            // 흰색 바탕의 간단한 이미지 파일임을 가정
            Console.Write("이미지 파일의 경로: ");
            Bitmap inputImage = new Bitmap(Console.ReadLine(), true);
            inputImage = GetResizedBitmap(inputImage, 80); // width 80의 아스키 문자열로 표시
            string result = ConvertToAscii(inputImage);
            Console.WriteLine(result);
        }

        // 아스키 문자열의 폭과 동일하도록 이미지 리사이징
        private static Bitmap GetResizedBitmap(Bitmap bitmap, int asciiWidth)
        {
            // scale factor = ascii width / image width
            // ascii height = scale factor * image height
            int asciiHeight = (int)Math.Ceiling((double)asciiWidth / bitmap.Width * bitmap.Height);

            Bitmap resizedBitmap = new Bitmap(asciiWidth, asciiHeight);
            Graphics graphics = Graphics.FromImage(resizedBitmap);
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(bitmap, 0, 0, asciiWidth, asciiHeight);
            graphics.Dispose();

            return resizedBitmap;
        }

        // 이미지 --> 아스키 문자열
        private static string ConvertToAscii(Bitmap bitmap)
        {
            StringBuilder sb = new StringBuilder();

            Random rnd = new Random();

            for (int h = 0; h < bitmap.Height; h++)
            {
                for (int w = 0; w < bitmap.Width; w++)
                {
                    // 이미지의 각 픽셀에 대해 계산된 그레이 컬러(0~255)의 값이 128보다 작으면 화면에 임의 문자 출력
                    Color pixelColor = bitmap.GetPixel(w, h);
                    int rgb = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    Color grayColor = Color.FromArgb(rgb, rgb, rgb);

                    char asciiChar = Convert.ToChar(rnd.Next(33, 126 + 1));
                    if (grayColor.R < 128)
                    {
                        sb.Append(asciiChar);
                    }
                    else
                    {
                        sb.Append(" ");
                    }

                }
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
