using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace CarryBuddy.SDK
{
    public class MouseEvents
    {
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);


        public static void MouseMove(int x, int y)
        {
            SetCursorPos(x, y);
        }
        
        public static void MouseMoveRelative(int xOffset, int yOffset)
        {
            SetCursorPos(Cursor.Position.X + xOffset, Cursor.Position.Y + yOffset);
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        private const uint MOUSEEVENTF_LEFTUP = 0x04;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const uint MOUSEEVENTF_RIGHTUP = 0x10;


        private static void MouseEvent(uint mouseEvent, uint x, uint y)
        {
            Utilities.System.Sleep(Humanizer.KeyDelay);
            mouse_event(mouseEvent, x, y, 0, 0);
        }

        /// <summary>
        /// Holds down the mouse left button.
        /// </summary>

        public static void MouseLeftDown()
        {
            MouseEvent(MOUSEEVENTF_LEFTDOWN, (uint)Cursor.Position.X, (uint)Cursor.Position.Y);
        }

        /// <summary>
        /// Releases the mouse left button.
        /// </summary>

        public static void MouseLeftUp()
        {
            MouseEvent(MOUSEEVENTF_LEFTUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y);
        }

        /// <summary>
        /// Performs a mouse left click.
        /// </summary>

        public static void MouseClickLeft()
        {
            MouseLeftDown();
            MouseLeftUp();
        }

        /// <summary>
        /// Holds down the mouse right button.
        /// </summary>

        public static void MouseRightDown()
        {
            MouseEvent(MOUSEEVENTF_RIGHTDOWN, (uint)Cursor.Position.X, (uint)Cursor.Position.Y);
        }

        /// <summary>
        /// Releases the mouse right button.
        /// </summary>

        public static void MouseRightUp()
        {
            MouseEvent(MOUSEEVENTF_RIGHTUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y);
        }

        /// <summary>
        /// Performs a mouse right click.
        /// </summary>

        public static void MouseClickRight()
        {
            MouseRightDown();
            MouseRightUp();
        }

        /// <summary>
        /// Moves the mouse to (<paramref name="start_x"/>, <paramref name="start_y"/>),
        /// holds down left button, offsets the mouse by
        /// (<paramref name="x_offset"/>, <paramref name="y_offset"/>) and
        /// releases left button.
        /// </summary>
        /// 
        /// <param name="start_x">Abscissa of the beginning.</param>
        /// <param name="start_y">Ordinate of the beginning.</param>
        /// <param name="x_offset">Relative abscissa offset.</param>
        /// <param name="y_offset">Relative ordinate offset.</param>

        public static void DragAndDropRelative(int start_x, int start_y, int x_offset, int y_offset)
        {
            MouseMove(start_x, start_y);

            Utilities.System.Sleep(100);

            MouseLeftDown();

            Utilities.System.Sleep(30);

            MouseMoveRelative(x_offset, y_offset);

            Utilities.System.Sleep(30);

            MouseLeftUp();
        }

        /// <summary>
        /// Moves the mouse to (<paramref name="start_x"/>, <paramref name="start_y"/>),
        /// holds down left button, moves the mouse to
        /// (<paramref name="final_x"/>, <paramref name="final_y"/>) and
        /// releases left button.
        /// </summary>
        /// 
        /// <param name="start_x">Abscissa of the beginning.</param>
        /// <param name="start_y">Ordinate of the beginning.</param>
        /// <param name="final_x">Abscissa of the final.</param>
        /// <param name="final_y">Ordinate of the final.</param>

        public static void DragAndDrop(int start_x, int start_y, int final_x, int final_y)
        {
            DragAndDropRelative(start_x, start_y, final_x - start_x, final_y - start_y);
        }

        /// <summary>
        /// Moves the move to the given coordinates.
        /// </summary>
        /// 
        /// <param name="coords">Array of size 2 with the abscissa and the
        /// ordinate respectively.</param>
        /// 
        /// <returns>
        /// <code>true</code> if <paramref name="coords"/> has size 2. Otherwise,
        /// returns <code>false</code>.
        /// </returns>

        public static bool MoveMouseToCoords(int[] coords)
        {
            bool success = coords.Length == 2;

            if (success)
            {
                MouseMove(coords[0], coords[1]);
            }

            return success;
        }

        /// <summary>
        /// Taking x and y as the coordinates of the pixel with color
        /// <paramref name="pixel_color"/>, moves the mouse to the point
        /// (x + <paramref name="x_offset"/>, y + <paramref name="y_offset"/>).
        /// </summary>
        /// 
        /// <param name="pixel_color">Pixel color.</param>
        /// <param name="x_offset">Pixel abscissa offset.</param>
        /// <param name="y_offset">Pixel ordinate offset.</param>
        /// 
        /// <returns>
        /// <code>true</code> if the pixel is found. Otherwise, returns
        /// <code>false</code>.
        /// </returns>

        public static bool MoveMouseToPixelCoordsWithOffset(PixelColor pixel_color, int x_offset, int y_offset)
        {
            bool success = false;
            int[] pixelCoords = Window.GetPixelCoordsInLoLWindow(pixel_color);

            if (pixelCoords.Length == 2)
            {
                success = true;
                MoveMouseToCoords(Utilities.Geometry.MoveCoords(pixelCoords, x_offset, y_offset));
            }

            return success;
        }

        /// <summary>
        /// Moves the mouse to the pixel with color <paramref name="pixel_color"/>.
        /// </summary>
        /// 
        /// <param name="pixel_color">Pixel color.</param>
        /// 
        /// <returns>
        /// <code>true</code> if the pixel is found. Otherwise, returns
        /// <code>false</code>.
        /// </returns>

        public static bool MoveMouseToPixelCoords(PixelColor pixel_color)
        {
            return MoveMouseToPixelCoordsWithOffset(pixel_color, 0, 0);
        }


        /// <summary>
        /// Gets the current mouse coordinates of X and Y then store it into the PrevCoordStorage Class
        /// </summary>
        public static void GetandSetCurrentPos()
        {
            var position = new Point(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y);
            PrevCoordStorage.PrevXCoord = position.X;
            PrevCoordStorage.PrevYCoord = position.Y;
        }
        
        /// <summary>
        /// Coordinates of X and Y of previous mouse coordinate
        /// </summary>
        public class PrevCoordStorage
        {
            public static int PrevXCoord = 0;
            public static int PrevYCoord = 0;
        }

        /// <summary>
        /// Moves the mouse the previous coordinate from the PrevCoordStorage
        /// </summary>
        public static void SetToPrevPos()
        {
            System.Windows.Forms.Cursor.Position = new Point(PrevCoordStorage.PrevXCoord, PrevCoordStorage.PrevYCoord);
        }

        /// <summary>
        /// Clear out the stored previous mouse coordinate
        /// </summary>
        public static void ClearPrevCoords()
        {
            PrevCoordStorage.PrevXCoord = 0;
            PrevCoordStorage.PrevYCoord = 0;
        }

    }
}
