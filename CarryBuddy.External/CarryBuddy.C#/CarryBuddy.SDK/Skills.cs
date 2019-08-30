using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryBuddy.SDK
{
    public class Skills
    {
        private static int[] BASE_PIXEL_COORDS = { 0, 0 };
        private const int Q_X_OFFSET = 131; // this offset is relative to the base pixel and represents the abscissa of the upper left corner of Q
        private const int Q_Y_OFFSET = -45; // this offset is relative to the base pixel and represents the ordinate of the upper left corner of Q
        private static int[] Q_COOLDOWN_COORDS = { 0, 0, 0, 0 };
        //global Q_COOLDOWN_COORDS = [ (542 / BASE_RESOLUTION_WIDTH) * A_ScreenWidth, (643 / BASE_RESOLUTION_HEIGHT) * A_ScreenHeight, (542 / BASE_RESOLUTION_WIDTH) * A_ScreenWidth + 20, (643 / BASE_RESOLUTION_HEIGHT) * A_ScreenHeight + 20 ] // coords of the rectangle of the cooldown number
        //global BASE_Q_COOLDOWN_COORDS = [ 542, 643, 542 + 20, 643 + 20 ] // coords of the rectangle of the cooldown number
        //global Q_COOLDOWN_COORDS = [ XToCurrentResolution(542), YToCurrentResolution(643), XToCurrentResolution(542) + 20, YToCurrentResolution(643) + 20 ] // coords of the rectangle of the cooldown number
        //global BASE_Q_COOLDOWN_COORDS = [ 542, 643, 542 + 20, 643 + 20 ] // coords of the rectangle of the cooldown number
        private const int SKILLS_OFFSET = 45; // x offset between two upper left corners of two skills (side by side)

        /// <summary>
        /// Updates important variables in the Skills class.
        /// </summary>

        public static void UpdateSkillsVariable()
        {
            Window.UpdateWindowSize();

            BASE_PIXEL_COORDS =
                Screen.GetPixelCoords
                (
                    Window.leagueRectangle.Left + 4,
                    Window.leagueRectangle.Top + Window.leagueHeight - 42,
                    Window.leagueRectangle.Left + Window.leagueWidth / 2,
                    Window.leagueRectangle.Top + Window.leagueHeight - 4,
                    new PixelColor(0x18, 0x6C, 0x4A)
                );

            Q_COOLDOWN_COORDS[0] = BASE_PIXEL_COORDS[0] + Q_X_OFFSET + 8;
            Q_COOLDOWN_COORDS[1] = BASE_PIXEL_COORDS[1] + Q_Y_OFFSET + 8;
            Q_COOLDOWN_COORDS[2] = BASE_PIXEL_COORDS[0] + Q_X_OFFSET + 8 + 15;
            Q_COOLDOWN_COORDS[3] = BASE_PIXEL_COORDS[1] + Q_Y_OFFSET + 8 + 15;
        }

        public static void CastQ()
        {
            KeyEvents.SendKey(KeyEvents.KeyBoardScanCodes.KEY_Q);
        }

        public static void CastW()
        {
            KeyEvents.SendKey(KeyEvents.KeyBoardScanCodes.KEY_W);
        }

        public static void CastE()
        {
            KeyEvents.SendKey(KeyEvents.KeyBoardScanCodes.KEY_E);
        }

        public static void CastR()
        {
            KeyEvents.SendKey(KeyEvents.KeyBoardScanCodes.KEY_R);
        }
        
        /// <summary>
        /// Checks if a skill is on cooldown.
        /// </summary>
        /// 
        /// <param name="skill">Letter that represents the skill
        /// ("q", "Q", "w", "W", "e", "E", "r", "R").</param>
        /// 
        /// <returns>
        /// <code>true</code> if the skill in on cooldown. Otherwise, returns
        /// <code>false</code>.
        /// </returns>

        private static bool SkillIsOnCooldown(string skill)
        {
            UpdateSkillsVariable();
            skill.ToLower();

            int offset = 0;

            if (skill == "q")
                offset = 0;

            else if (skill == "w")
                offset = 1;

            else if (skill == "e")
                offset = 2;

            else if (skill == "r")
                offset = 3;

            else
                offset = -7;

            return Screen.PixelExists(Q_COOLDOWN_COORDS[0] + offset * SKILLS_OFFSET, Q_COOLDOWN_COORDS[1], Q_COOLDOWN_COORDS[2] + offset * SKILLS_OFFSET, Q_COOLDOWN_COORDS[3], new PixelColor(0xFF, 0xFF, 0xFF));
        }


        // Checks if Q is on cooldown
        // 
        // Returns true if Q is on cooldown. Otherwise, returns false

        public static bool QIsOnCooldown()
        {
            return SkillIsOnCooldown("q");
        }


        // Checks if W is on cooldown
        // 
        // Returns true if W is on cooldown. Otherwise, returns false

        public static bool WIsOnCooldown()
        {
            return SkillIsOnCooldown("w");
        }


        // Checks if E is on cooldown
        // 
        // Returns true if E is on cooldown. Otherwise, returns false

        public static bool EIsOnCooldown()
        {
            return SkillIsOnCooldown("e");
        }


        // Checks if R is on cooldown
        // 
        // Returns true if R is on cooldown. Otherwise, returns false

        public static bool RIsOnCooldown()
        {
            return SkillIsOnCooldown("r");
        }
    }
}
