using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CarryBuddy.SDK
{
    public class Screen
    {
        private const int BASE_RESOLUTION_WIDTH = 1366;
        private const int BASE_RESOLUTION_HEIGHT = 768;
        private static int currentResolutionWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        private static int currentResolutionHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
        private static int widthVariation = currentResolutionWidth - BASE_RESOLUTION_WIDTH;
        private static int heightVariation = currentResolutionWidth - BASE_RESOLUTION_HEIGHT;
        private static float currentResolutionWidthPerBaseResolutionWidth = currentResolutionWidth / BASE_RESOLUTION_WIDTH;
        private static float currentResolutionHeightPerBaseResolutionHeight = currentResolutionHeight / BASE_RESOLUTION_HEIGHT;
        public const float UNITS_PER_PIXEL = 625 / 267;
        public const float PIXELS_PER_UNIT = 267 / 625;

        /// <summary>
        /// Updates important variables about the screen.
        /// </summary>

        public static void UpdateScreenVariables()
        {
            currentResolutionWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            currentResolutionHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            widthVariation = currentResolutionWidth - BASE_RESOLUTION_WIDTH;
            heightVariation = currentResolutionHeight - BASE_RESOLUTION_HEIGHT;
            currentResolutionWidthPerBaseResolutionWidth = 1.0f * currentResolutionWidth / BASE_RESOLUTION_WIDTH;
            currentResolutionHeightPerBaseResolutionHeight = 1.0f * currentResolutionHeight / BASE_RESOLUTION_HEIGHT;
            /* VARIABLE DEBUG TEMPLATE :kappa:
            MessageBox.Show
            (
                "currentResolutionWidth = " + currentResolutionWidth +
                "\ncurrentResolutionHeight = " + currentResolutionHeight +
                "\nBASE_RESOLUTION_WIDTH = " + BASE_RESOLUTION_WIDTH +
                "\nBASE_RESOLUTION_HEIGHT = " + BASE_RESOLUTION_HEIGHT +
                "\nwidthVariation = " + widthVariation +
                "\nheightVariation = " + heightVariation +
                "\ncurrentResolutionWidthPerBaseResolutionWidth = " + currentResolutionWidthPerBaseResolutionWidth +
                "\ncurrentResolutionHeightPerBaseResolutionHeight = " + currentResolutionHeightPerBaseResolutionHeight
            );
            */
        }

        /// <summary>
        /// Converts an x offset in the base resolution to an x offset in the
        /// current resolution.
        /// </summary>
        /// 
        /// <param name="horizontal_offset_in_the_base_resolution">x offset
        /// in the base resolution</param>
        /// 
        /// <returns>
        /// The corresponding offset in the current resolution.
        /// </returns>

        public static int XToCurrentResolution(int horizontal_offset_in_the_base_resolution)
        {
            UpdateScreenVariables();
            
            return (int)( horizontal_offset_in_the_base_resolution * currentResolutionWidthPerBaseResolutionWidth + ((widthVariation / -342) * 30) );
        }

        /// <summary>
        /// Converts an y offset in the base resolution to an y offset in the
        /// current resolution.
        /// </summary>
        /// 
        /// <param name="vertical_offset_in_the_base_resolution">y offset
        /// in the base resolution</param>
        /// 
        /// <returns>
        /// The corresponding offset in the current resolution.
        /// </returns>

        public static int YToCurrentResolution(int vertical_offset_in_the_base_resolution)
        {
            UpdateScreenVariables();
            return (int)(((heightVariation / -342) * 30) + vertical_offset_in_the_base_resolution * currentResolutionHeightPerBaseResolutionHeight);
        }

        /// <summary>
        /// Traverses the given rectangle collecting all of it's pixels.
        /// </summary>
        /// 
        /// <param name="upperLeftPoint">Rectangle upper left corner.</param>
        /// <param name="width">Rectangle width.</param>
        /// <param name="height">Rectangle height.</param>
        /// 
        /// <returns>
        /// Rectangle's bitmap.
        /// </returns>

        public static Bitmap GetScreenBitmap(Point upperLeftPoint, int width, int height)
        {
            Bitmap screenBitmap = new Bitmap(width, height);
            Graphics screenGraphics = Graphics.FromImage(screenBitmap);

            screenGraphics.CopyFromScreen(upperLeftPoint, new Point(0, 0), new Size(width, height));

            return screenBitmap;
        }

        /// <summary>
        /// Searches the coordinates of a pixel with the color
        /// RGBA(<paramref name="red"/>, <paramref name="green"/>,
        /// <paramref name="blue"/>, <paramref name="alpha"/>) in
        /// <paramref name="bitmap"/> from left to right, line by line.
        /// </summary>
        /// 
        /// <param name="bitmap">Search bitmap.</param>
        /// <param name="red">Color red intensity.</param>
        /// <param name="green">Color green intensity.</param>
        /// <param name="blue">Color blue intensity.</param>
        /// <param name="alpha">Color opacity intensity.</param>
        /// 
        /// <returns>
        /// The pixel coordinates relative to the upper left corner of
        /// the bitmap.
        /// </returns>

        public static unsafe int[] PixelSearch(Bitmap bitmap, byte red, byte green, byte blue, byte alpha)
        {
            int[] pixelCoords = new int[0];
            BitmapData imageData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            int bytesPerPixel = 3;

            byte* scan0 = (byte*)imageData.Scan0.ToPointer();
            int stride = imageData.Stride;

            byte* row = scan0 - stride;
            int blueIndex;

            for (int y = 0; pixelCoords.Length == 0 && y < imageData.Height; y++)
            {
                row += stride;

                for (int x = 0; pixelCoords.Length == 0 && x < imageData.Width; x++)
                {
                    
                    blueIndex = x * bytesPerPixel;

                    // Watch out for actual order (BGR)!
                    if (row[blueIndex] == blue &&
                        row[blueIndex + 1] == green &&
                        row[blueIndex + 2] == red)
                    {
                        pixelCoords = new int[] { x, y };
                    }
                }
            }

            bitmap.UnlockBits(imageData);

            return pixelCoords;
        }

        /// <summary>
        /// Searches the coordinates of a pixel with the color
        /// <paramref name="pixelColor"/> from left to right, line by line.
        /// </summary>
        /// 
        /// <param name="bitmap">Search bitmap.</param>
        /// <param name="pixelColor">Pixel color.</param>
        /// 
        /// <returns>
        /// The pixel coordinates relative to the upper left corner of
        /// the bitmap.
        /// </returns>

        public static int[] PixelSearch(Bitmap bitmap, PixelColor pixelColor)
        {
            return PixelSearch(bitmap,
                pixelColor.red,
                pixelColor.green,
                pixelColor.blue,
                pixelColor.alpha);
        }

        /// <summary>
        /// Gets the color of the pixel in the point <paramref name="position"/>.
        /// </summary>
        /// 
        /// <param name="position">Pixel point on the screen.</param>
        /// 
        /// <returns>
        /// The pixel color.
        /// </returns>

        public static PixelColor PixelGetColor(Point position)
        {
            Bitmap bitmap = GetScreenBitmap(position, 1, 1);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(new Point(0, 0), new Size(1, 1)), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            PixelColor pixelColor = null;

            unsafe
            {
                byte* scan0 = (byte*)bitmapData.Scan0;

                // byte0 -> blue
                // byte1 -> green
                // byte2 -> red
                pixelColor = new PixelColor(scan0[2], scan0[1], scan0[0]);
            }

            bitmap.UnlockBits(bitmapData);

            return pixelColor;
        }

        /// <summary>
        /// Gets the color of the pixel in the point
        /// (<paramref name="coords"/>[0], <paramref name="coords"/>[1]).
        /// </summary>
        /// 
        /// <param name="coords">Array with the abscissa and the ordinate of
        /// the point respectively.</param>
        /// 
        /// <returns>
        /// <code>null</code> if <paramref name="coords"/> does not has size 2.
        /// Otherwise, the pixel color.
        /// </returns>

        public static PixelColor PixelGetColor(int[] coords)
        {
            PixelColor pixelColor = null;

            if (coords.Length == 2)
            {
                pixelColor = PixelGetColor(new Point(coords[0], coords[1]));
            }

            return pixelColor;
        }

        /// <summary>
        /// Traverses the given rectangle collections all of it's pixel colors
        /// from left to right, line by line.
        /// </summary>
        /// 
        /// <param name="upper_left_x">Abscissa of the upper left corner.</param>
        /// <param name="upper_left_y">Ordinate of the upper left corner.</param>
        /// <param name="lower_right_x">Abscissa of the lower right corner.</param>
        /// <param name="lower_right_y">Ordinate of the lower right corner.</param>
        /// 
        /// <returns>
        /// An empty array if <paramref name="lower_right_x"/> &lt; <paramref name="upper_left_x"/>
        /// or <paramref name="lower_right_y"/> &lt; <paramref name="upper_left_y"/>. Otherwise,
        /// returns an unidimensional array with each pixel color.
        /// </returns>

        public static PixelColor[] GetAllPixelColors(int upper_left_x, int upper_left_y, int lower_right_x, int lower_right_y)
        {
            int numberOfColumns = lower_right_x - upper_left_x + 1;
            int numberOfLines = lower_right_y - upper_left_y + 1;
            PixelColor[] pixels = new PixelColor[0];

            if (numberOfColumns > 0 && numberOfLines > 0)
            {
                Bitmap screenBitmap = GetScreenBitmap(new Point(upper_left_x, upper_left_y), numberOfColumns, numberOfLines);
                BitmapData bitmapData = screenBitmap.LockBits(new Rectangle(new Point(0, 0), screenBitmap.Size), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int numberOfPixels = numberOfLines * numberOfColumns;
                pixels = new PixelColor[numberOfPixels];

                unsafe
                {
                    byte* scan0 = (byte*)bitmapData.Scan0.ToPointer();
                    int bytesPerPixel = 3;

                    for (int i = 0; i < numberOfPixels; i++)
                    {
                        pixels[i] = new PixelColor(scan0[2], scan0[1], scan0[0]);
                        scan0 += bytesPerPixel;
                    }
                }

                screenBitmap.UnlockBits(bitmapData);
            }

            return pixels;
        }

        /// <summary>
        /// Searches a pixel with the color <paramref name="pixel_color"/> in a
        /// rectangle on the screen from left to right, line by line.
        /// </summary>
        /// 
        /// <param name="upper_left_x">Abscissa of the upper left corner.</param>
        /// <param name="upper_left_y">Ordinate of the upper left corner.</param>
        /// <param name="lower_right_x">Abscissa of the lower right corner.</param>
        /// <param name="lower_right_y">Ordinate of the lower right corner.</param>
        /// <param name="pixel_color">Pixel color.</param>
        /// 
        /// <returns>
        /// An empty array if the pixel is not found. Otherwise, returns an array
        /// of size 2 with the abscissa and the ordinate of the point respectively
        /// relative to the screen.
        /// </returns>

        public static int[] GetPixelCoords(int upper_left_x, int upper_left_y, int lower_right_x, int lower_right_y, PixelColor pixel_color)
        {
            return
                Utilities.Geometry.MoveCoords
                (
                    PixelSearch
                    (
                        GetScreenBitmap
                        (
                            new Point(upper_left_x, upper_left_y),
                            lower_right_x - upper_left_x,
                            lower_right_y - upper_left_y
                        ),

                        pixel_color
                    ),

                    upper_left_x,
                    upper_left_y
                );
        }

        /// <summary>
        /// Searches a pixel with the color <paramref name="pixel_color"/> in a
        /// rectangle on the screen from left to right, line by line.
        /// </summary>
        /// 
        /// <param name="upper_left_x">Abscissa of the upper left corner.</param>
        /// <param name="upper_left_y">Ordinate of the upper left corner.</param>
        /// <param name="lower_right_x">Abscissa of the lower right corner.</param>
        /// <param name="lower_right_y">Ordinate of the lower right corner.</param>
        /// <param name="pixel_color">Pixel color.</param>
        /// 
        /// <returns>
        /// <code>true</code> if the pixel exists in the specified rectangle.
        /// Otherwise, returns <code>false</code>.
        /// </returns>

        public static bool PixelExists(int upper_left_x, int upper_left_y, int lower_right_x, int lower_right_y, PixelColor pixel_color)
        {
            return GetPixelCoords(upper_left_x, upper_left_y, lower_right_x, lower_right_y, pixel_color).Length == 2;
        }
    }
}
