using System;

namespace CarryBuddy.SDK.Utilities
{
    public class Geometry
    {
        /// <summary>
        /// Converts the distance in pixel to units of the game.
        /// </summary>
        /// 
        /// <param name="pixels_distance">Pixels distance.</param>
        /// 
        /// <returns>
        /// The equivalent distance in units of the game to the pixels distance.
        /// </returns>

        public static float ConvertDistanceInPixelsToUnits(float pixels_distance)
        {
            return pixels_distance * Screen.UNITS_PER_PIXEL;
        }

        /// <summary>
        /// Converts the distance in units of the game to pixels distance.
        /// </summary>
        /// 
        /// <param name="units_distance">Units distance.</param>
        /// 
        /// <returns>
        /// The equivalent pixels distance of the units distance.
        /// </returns>

        public static float ConvertDistanceInUnitsToPixels(float units_distance)
        {
            return units_distance * Screen.PIXELS_PER_UNIT;
        }

        /// <summary>
        /// Creates the new coordinates
        /// (<paramref name="coords"/>[0] + <paramref name="x_offset"/>,
        ///  <paramref name="coords"/>[1] + <paramref name="y_offset"/>).
        /// </summary>
        /// 
        /// <param name="coords">Point coordinates.</param>
        /// <param name="x_offset">Abscissa offset.</param>
        /// <param name="y_offset">Ordinate offset.</param>
        /// 
        /// <returns>
        /// An array of size 2 with the abscissa and the ordinate of
        /// <paramref name="coords"/> shifted.
        /// </returns>

        public static int[] MoveCoords(int[] coords, int x_offset, int y_offset)
        {
            int[] newCoords = new int[0];

            if (coords.Length == 2)
            {
                newCoords = new int[] { coords[0] + x_offset, coords[1] + y_offset };
            }

            return newCoords;
        }


        /// <summary>
        /// Calculates the distance between <paramref name="point1_coords"/> and
        /// <paramref name="point2_coords"/>.
        /// </summary>
        /// 
        /// <param name="point1_coords">Coordinates of the first point.</param>
        /// <param name="point2_coords">Coordinates of the second point.</param>
        /// 
        /// <returns>
        /// 1 billion if <paramref name="point1_coords"/> or
        /// <paramref name="point2_coords"/> does not has size 2. Otherwise,
        /// returns the distance between them.
        /// </returns>

        public static float GetDistanceBetweenPoints(int[] point1_coords, int[] point2_coords)
        {
            float distance = 1000000000.0f; // 10 digits on the integer part

            if (point1_coords.Length == 2 && point2_coords.Length == 2)
            {
                int deltaX = point2_coords[0] - point1_coords[0];
                int deltaY = point2_coords[1] - point1_coords[1];

                distance = (float) Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            }

            return distance;
        }
    }
}
