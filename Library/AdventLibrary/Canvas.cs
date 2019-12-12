using System.Drawing;

namespace AdventLibrary {
    public class Canvas {
        public static Bitmap Draw(int[,] picture, string colorName) {
            var size = picture.GetLength(0) > picture.GetLength(1) ? picture.GetLength(0) : picture.GetLength(1);
            var sizePowerOfTwo = 2;
            while (size > sizePowerOfTwo) {
                sizePowerOfTwo *= 2;
            }

            var image = new Bitmap(sizePowerOfTwo, sizePowerOfTwo);
            var color = Color.FromName(colorName);

            for (int i = 0; i < picture.GetLength(0); i++) {
                for (int j = 0; j < picture.GetLength(1); j++) {
                    if (picture[i, j] == 1)
                        image.SetPixel(i, j, color);
                    else {
                        image.SetPixel(i, j, Color.White);
                    }
                }
            }

            return image;
        }


        public static Bitmap Add(Bitmap image1, Bitmap image2) {
            var image = new Bitmap(image1.Width, image1.Height);
            for (int w = 0; w < image1.Width; w++) {
                for (int h = 0; h < image1.Height; h++) {
                    var color1 = image1.GetPixel(w, h);
                    var color2 = image2.GetPixel(w, h);

                    var c = (R: color1.R + color2.R, G: color1.G + color2.G, B: color1.B + color2.B, A: color1.A + color2.A);
                    var color = Color.FromArgb(c.A, c.R, c.G, c.B);
                    
                    image.SetPixel(w, h, color);
                }
            }

            return image;
        }
    }
}