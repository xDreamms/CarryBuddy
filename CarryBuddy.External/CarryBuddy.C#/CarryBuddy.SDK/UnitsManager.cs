using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryBuddy.SDK
{
    public class UnitsManager
    {
        public static PixelColor RGB_CHAMPION_NAME_COLOR = new PixelColor(0xE3, 0xE3, 0xE3);
        public static PixelColor RGB_LOSED_HP_BAR_COLOR = new PixelColor(0x0A, 0x0E, 0x11);
        public static PixelColor RGB_MANA_BAR_COLOR = new PixelColor(0x42, 0xAA, 0xDE);

        public static PixelColor RGB_ALLY_HP_BAR_COLOR = new PixelColor(0x31, 0x8A, 0x21);
        public static PixelColor RGB_ALLY_LEVEL_COLOR = new PixelColor(0x00, 0x1C, 0x2C);
        public static PixelColor RGB_ALLY_MINION_HP_BAR_COLOR = new PixelColor(0x2B, 0x5D, 0x79);

        public static PixelColor RGB_ENEMY_HP_BAR_COLOR = new PixelColor(0x94, 0x24, 0x18);
        public static PixelColor RGB_ENEMY_LEVEL_COLOR = new PixelColor(0x35, 0x03, 0x00);
        public static PixelColor RGB_ENEMY_MINION_HP_BAR_COLOR = new PixelColor(0x79, 0x39, 0x37);

        /// <summary>
        /// Checks if the player is dead.
        /// </summary>
        /// 
        /// <returns>
        /// <code>true</code> if the player is dead. Otherwise, returns
        /// <code>false</code>.
        /// </returns>

        public static bool PlayerIsDead()
        {
            return
                Screen.PixelExists
                (
                    Screen.XToCurrentResolution(430),
                    Screen.YToCurrentResolution(650),
                    Screen.XToCurrentResolution(430) + 30,
                    Screen.YToCurrentResolution(650) + 30,
                    new PixelColor(0xFF, 0x00, 0x00)
                );
        }


        // Calculates the player coordinates.
        // 
        // Returns 

        /// <summary>
        /// Calculates the player coordinates on the screen. Lock camera is assumed.
        /// </summary>
        /// 
        /// <returns>
        /// An array of size 2 with the abscissa and the ordinate of the player
        /// respectively.
        /// </returns>

        public static int[] GetPlayerCoords()
        {
            return Utilities.Geometry.MoveCoords(Window.GetCenterCoords(), -50, -25);
        }

        /// <summary>
        /// Calculates the coordinates of the most above and left enemy.
        /// </summary>
        /// 
        /// <returns>
        /// An empty array of the enemy is not found. Otherwise, an array of
        /// size 2 with the abscissa and the ordinate of the enemy respectively.
        /// </returns>

        public static int[] GetEnemyCoords()
        {
            return
                Utilities.Geometry.MoveCoords
                (
                    Window.GetPixelCoordsInLoLWindow(RGB_ENEMY_LEVEL_COLOR),
                    50, 80
                );
        }

        /// <summary>
        /// Calculates the distance between the player and the most above and
        /// left enemy in game units.
        /// </summary>
        /// 
        /// <returns>
        /// The distance between the player and the most above and
        /// left enemy in game units.
        /// </returns>

        public static float GetDistanceBetweenPlayerAndEnemy()
        {
            return
                Utilities.Geometry.ConvertDistanceInPixelsToUnits
                (
                    Utilities.Geometry.GetDistanceBetweenPoints
                    (
                        GetPlayerCoords(), GetEnemyCoords()
                    )
                );
        }


        /// <summary>
        /// Moves the mouse to the center of the player's champion.
        /// </summary>

        public static void MoveMouseToMe()
        {
            MouseEvents.MoveMouseToCoords(GetPlayerCoords());
        }

        /// <summary>
        /// Moves the mouse to the most above and left enemy.
        /// </summary>
        /// 
        /// <returns>
        /// <code>true</code> if the enemy is found. Otherwise, <code>false</code>.
        /// </returns>

        public static bool MoveMouseToEnemy()
        {
            return MouseEvents.MoveMouseToCoords(GetEnemyCoords());
        }

        /// <summary>
        /// Moves the mouse to the most above and left enemy and attack it.
        /// </summary>
        /// 
        /// <returns>
        /// <code>true</code> if the enemy is found. Otherwise, <code>false</code>.
        /// </returns>

        public static bool AttackEnemy()
        {
            bool success = MoveMouseToEnemy();

            if (success)
            {
                MouseEvents.MouseClickRight();
            }

            return success;
        }
    }
}
