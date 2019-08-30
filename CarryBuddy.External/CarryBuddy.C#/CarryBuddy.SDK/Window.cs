using System;
using System.Runtime.InteropServices;

namespace CarryBuddy.SDK
{
    public class Window
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public static RECT leagueRectangle = new RECT()
        { Left = 0, Top = 0, Right = 1024, Bottom = 768 }; // random values

        public const string WINDOW_TITLE = "League of Legends (TM) Client";
        public static int leagueWidth = leagueRectangle.Right - leagueRectangle.Left + 1;
        public static int leagueHeight = leagueRectangle.Bottom - leagueRectangle.Top + 1;

        /// <summary>
        /// Updates LoL window position and size.
        /// </summary>

        public static void UpdateWindowSize()
        {
            GetWindowRect(Utilities.System.GetWindowHandleByTitle(WINDOW_TITLE), out leagueRectangle);
            
            leagueWidth = leagueRectangle.Right - leagueRectangle.Left;
            leagueHeight = leagueRectangle.Bottom - leagueRectangle.Top;
        }

        /// <summary>
        /// Recalculates the coordinates of the center of the LoL window.
        /// </summary>
        /// 
        /// <returns>
        /// An array of size 2 with the abscissa and the ordinate of the
        /// center respectively.
        /// </returns>

        public static int[] GetCenterCoords()
        {
            UpdateWindowSize();

            return new int[]
            {
                leagueRectangle.Left + (leagueWidth / 2),
                leagueRectangle.Top + (leagueHeight / 2)
            };
        }

        /// <summary>
        /// Calculates the LoL window coordinates on the screen.
        /// The coordinates already ignores the window borders and title.
        /// </summary>
        /// 
        /// <returns>
        /// An array of size 4 with the coordinates of the upper left and lower
        /// right corners of the window respectively.
        /// </returns>

        public static int[] getLoLWindowCoords()
        {
            UpdateWindowSize();

            return new int[]
            {
                leagueRectangle.Left + 4, // skip window border
                leagueRectangle.Top + 23, // skip window border and title
                leagueRectangle.Left + leagueWidth - 4, // skip window border
                leagueRectangle.Top + leagueHeight - 4 // skip window border
            };
        }
        
        /// <summary>
        /// Searches a pixel with the color <paramref name="pixel_color"/> in
        /// the LoL window.
        /// </summary>
        /// 
        /// <param name="pixel_color">Pixel color in RGB.</param>
        /// 
        /// <returns>
        /// An empty array if the pixel is not found. Otherwise,
        /// returns an array of size 2 with the abscissa and the ordinate
        /// of the point respectively.
        /// </returns>

        public static int[] GetPixelCoordsInLoLWindow(PixelColor pixel_color)
        {
            int[] lolWindowCoords = getLoLWindowCoords();

            return Screen.GetPixelCoords(lolWindowCoords[0], lolWindowCoords[1], lolWindowCoords[2], lolWindowCoords[3], pixel_color);
        }
        
        /// <summary>
        /// Searches a pixel with the color <paramref name="pixel_color"/> in
        /// the LoL window.
        /// </summary>
        /// 
        /// <param name="pixel_color">Pixel color in RGB.</param>
        /// 
        /// <returns>
        /// <code>true</code> if the pixel exists in the LoL window.
        /// Otherwise, returns <code>false</code>.
        /// </returns>

        public static bool PixelExistsInLoLWindow(PixelColor pixel_color)
        {
            int[] lolWindowCoords = getLoLWindowCoords();

            return Screen.PixelExists(lolWindowCoords[0], lolWindowCoords[1], lolWindowCoords[2], lolWindowCoords[3], pixel_color);
        }
    }
}
