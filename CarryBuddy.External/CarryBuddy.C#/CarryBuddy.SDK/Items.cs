using System.Collections;
using System.Windows.Forms;

namespace CarryBuddy.SDK
{
    public class Items
    {
        private const int ITEMS_WIDTH = 23;
        private const int ITEMS_HEIGHT = 23;
        /// <summary>
        /// x offset between two upper left corners of two items (side by side)
        /// </summary>
        private const int ITEMS_X_OFFSET = 31;
        /// <summary>
        /// y offset between two upper left corners of two items (one on top of the other)
        /// </summary>
        private const int ITEMS_Y_OFFSET = 31;

        private static int[] ITEMS_RECTANGLE =
        {
            Screen.XToCurrentResolution(795),
            Screen.YToCurrentResolution(635),
            Screen.XToCurrentResolution(795) + 2 * ITEMS_X_OFFSET + ITEMS_WIDTH,
            Screen.YToCurrentResolution(635) + ITEMS_Y_OFFSET + ITEMS_HEIGHT
        }; // does not include ward slot

        private static int[] WARD_RECTANGLE =
        {
            Screen.XToCurrentResolution(891),
            Screen.YToCurrentResolution(639),
            Screen.XToCurrentResolution(904),
            Screen.YToCurrentResolution(658)
        };

        public static PixelColor ITEM_BLADE_OF_THE_RUINED_KING_RGB_PIXEL_COLOR = new PixelColor(0x05, 0x04, 0x6B);
        public static PixelColor ITEM_BILGEWATER_CUTLASS_RGB_PIXEL_COLOR = new PixelColor(0x0E, 0x07, 0x00);
        public static PixelColor ITEM_CORRUPTING_POTION_RGB_PIXEL_COLOR = new PixelColor(0x77, 0x77, 0x77);
        public static PixelColor ITEM_HEALTH_POTION_RGB_PIXEL_COLOR = new PixelColor(0xFE, 0xFE, 0xFE);
        public static PixelColor ITEM_HEXTECH_REVOLVER_RGB_PIXEL_COLOR = new PixelColor(0xC6, 0xE3, 0xBD);
        public static PixelColor ITEM_HEXTECH_GUNBLADE_RGB_PIXEL_COLOR = new PixelColor(0xD6, 0xFB, 0xFB);
        public static PixelColor ITEM_KNIGHTS_VOW_RGB_PIXEL_COLOR = new PixelColor(0x8C, 0xA2, 0x9C);
        public static PixelColor ITEM_LOCKET_OF_THE_IRON_SOLARI_RGB_PIXEL_COLOR = new PixelColor(0xD6, 0xF3, 0xEF);
        public static PixelColor ITEM_MERCURIAL_SCIMITAR_RGB_PIXEL_COLOR = new PixelColor(0xF7, 0xF7, 0x84);
        public static PixelColor ITEM_MIKAELS_CRUCIBLE_RGB_PIXEL_COLOR = new PixelColor(0xFF, 0xEB, 0x7B);
        public static PixelColor ITEM_QUICKSILVER_SASH_RGB_PIXEL_COLOR = new PixelColor(0x9C, 0xA6, 0xAD);
        public static PixelColor ITEM_RANDUINS_OMEN_RGB_PIXEL_COLOR = new PixelColor(0xA5, 0x8E, 0x94);
        public static PixelColor ITEM_RAVENOUS_HYDRA_RGB_PIXEL_COLOR = new PixelColor(0xF7, 0xEF, 0xCE);
        public static PixelColor ITEM_REDEMPTION_RGB_PIXEL_COLOR = new PixelColor(0xF7, 0x14, 0x00);
        public static PixelColor ITEM_REFILLABLE_POTION_RGB_PIXEL_COLOR = new PixelColor(0xEF, 0xEF, 0xEF);
        public static PixelColor ITEM_RIGHTEOUS_GLORY_RGB_PIXEL_COLOR = new PixelColor(0x7B, 0x38, 0x21);
        public static PixelColor ITEM_SHURELYAS_REVERIE_RGB_PIXEL_COLOR = new PixelColor(0xFF, 0xFF, 0x94);
        public static PixelColor ITEM_SPELLBINDER_RGB_PIXEL_COLOR = new PixelColor(0x6D, 0x5C, 0xB5);
        public static PixelColor ITEM_STOPWATCH_RGB_PIXEL_COLOR = new PixelColor(0x7B, 0x55, 0x5A);
        public static PixelColor ITEM_TIAMAT_RGB_PIXEL_COLOR = new PixelColor(0xFF, 0xF7, 0x9C);
        public static PixelColor ITEM_TITANIC_HYDRA_RGB_PIXEL_COLOR = new PixelColor(0xF7, 0xFB, 0xE7);
        public static PixelColor ITEM_TWIN_SHADOWS_RGB_PIXEL_COLOR = new PixelColor(0xC6, 0xF7, 0xFF);
        public static PixelColor ITEM_YOUMUUS_GHOSTBLADE_RGB_PIXEL_COLOR = new PixelColor(0xFF, 0xDF, 0xFF);
        public static PixelColor ITEM_ZEKES_CONVERGE_RGB_PIXEL_COLOR = new PixelColor(0xFF, 0xB2, 0x5A);
        public static PixelColor ITEM_ZHONYAS_HOURGLASS_RGB_PIXEL_COLOR = new PixelColor(0xE7, 0xEF, 0xF7);
        public static PixelColor ITEM_ZZROT_PORTAL_RGB_PIXEL_COLOR = new PixelColor(0xFF, 0xF7, 0xFF);
        public static PixelColor ITEM_INFINITY_EDGE_RGB_PIXEL_COLOR = new PixelColor(0x4A, 0x2C, 0x10);
        public static PixelColor ITEM_STATTIK_SHIV_RGB_PIXEL_COLOR = new PixelColor(0xFF, 0xF3, 0xB5);
        public static PixelColor ITEM_ESSENCE_REAVER_RGB_PIXEL_COLOR = new PixelColor(0xF7, 0xFF, 0xFF);


        public static void UpdateItemsVariables()
        {
            ITEMS_RECTANGLE[0] = Screen.XToCurrentResolution(795);
            ITEMS_RECTANGLE[1] = Screen.YToCurrentResolution(635);
            ITEMS_RECTANGLE[2] = Screen.XToCurrentResolution(795) + 2 * ITEMS_X_OFFSET + ITEMS_WIDTH;
            ITEMS_RECTANGLE[3] = Screen.YToCurrentResolution(635) + ITEMS_Y_OFFSET + ITEMS_HEIGHT;
            
            WARD_RECTANGLE[0] = Screen.XToCurrentResolution(891);
            WARD_RECTANGLE[1] = Screen.YToCurrentResolution(639);
            WARD_RECTANGLE[2] = Screen.XToCurrentResolution(904);
            WARD_RECTANGLE[3] = Screen.YToCurrentResolution(658);
        }

        /// <summary>
        /// Uses the item on the slot <paramref name="itemSlot"/>.
        /// </summary>
        /// 
        /// <param name="itemSlot">Item slot number.</param>

        public static void UseItem(int itemSlot)
        {
            if (itemSlot > 0 && itemSlot < 8)
            {
                KeyEvents.SendKey(KeyEvents.KeyBoardScanCodes.KEY_1 + (short) itemSlot - 1);
            }
        }


        // Moves the item between the 3 horizontal slots and finds which pixel colors
        // were maintained between those changes.
        // 
        // Obs.: move the item to the slot 1 or 5 before calling this function.
        // 
        // start_x -> abscissa of the upper left corner of the item
        // start_y -> ordinate of the upper left corner of the item
        // 
        // Returns an array that contains all the common colors between slot changes.

        protected static ArrayList DetectItemCommonPixelColorsFor3HorizontalSlots(int start_x, int start_y)
        {
            int item_x = start_x;
            int item_y = start_y;
            PixelColor[] item_pixels1 = Screen.GetAllPixelColors(item_x, item_y, item_x + ITEMS_WIDTH, item_y + ITEMS_HEIGHT);
            PixelColor[] item_pixels2;
            ArrayList commonPixels1 = new ArrayList();
            ArrayList commonPixels2 = new ArrayList();
            commonPixels1.AddRange(item_pixels1);
            int i = 0;

            while (i < 2)
            {
                MouseEvents.DragAndDropRelative(item_x, item_y, ITEMS_X_OFFSET, 0);
                item_x += ITEMS_X_OFFSET;

                Utilities.System.Sleep(300);
                MouseEvents.MouseMove(0, 0);
                Utilities.System.Sleep(300);

                item_pixels2 = Screen.GetAllPixelColors(item_x, item_y, item_x + ITEMS_WIDTH, item_y + ITEMS_HEIGHT);
                commonPixels2.Clear();
                commonPixels2.AddRange(item_pixels2);

                commonPixels1 = Utilities.Arrays.GetCommonValues(commonPixels1, commonPixels2);

                Utilities.System.Sleep(300);

                i++;
            }

            return commonPixels1;
        }


        // Moves the item between all slots and finds which pixel colors were maintained between those changes.
        // 
        // Obs.: move the item to the slot 1 before calling this function.
        // 
        // Returns an array that contains all the common colors between slot changes.

        protected static ArrayList DetectItemCommonPixelColors()
        {
            UpdateItemsVariables();

            ArrayList common_colors1 = DetectItemCommonPixelColorsFor3HorizontalSlots(ITEMS_RECTANGLE[0], ITEMS_RECTANGLE[1]);

            Utilities.System.Sleep(300);
            MouseEvents.DragAndDrop(ITEMS_RECTANGLE[0] + ITEMS_X_OFFSET * 2, ITEMS_RECTANGLE[1], ITEMS_RECTANGLE[0], ITEMS_RECTANGLE[1] + ITEMS_Y_OFFSET);

            Utilities.System.Sleep(300);
            MouseEvents.MouseMove(0, 0);
            Utilities.System.Sleep(300);

            ArrayList common_colors2 = DetectItemCommonPixelColorsFor3HorizontalSlots(ITEMS_RECTANGLE[0], ITEMS_RECTANGLE[1] + ITEMS_Y_OFFSET);

            return Utilities.Arrays.GetCommonValues(common_colors1, common_colors2);
        }

        /// <summary>
        /// Obtains the slot of the item with the specified color.
        /// </summary>
        /// 
        /// <param name="item_color">Item color.</param>
        /// 
        /// <returns>
        /// -1 if the item is not found. Otherwise, the number of the item slot.
        /// </returns>
        
        public static int GetItemSlot(PixelColor item_color)
        {
            UpdateItemsVariables();

            int itemSlot = -1;
            int[] itemCoords = Screen.GetPixelCoords(ITEMS_RECTANGLE[0], ITEMS_RECTANGLE[1], ITEMS_RECTANGLE[2], ITEMS_RECTANGLE[3], item_color);

            if (itemCoords.Length == 2)
            {
                itemSlot = 1 + ((itemCoords[0] - ITEMS_RECTANGLE[0]) / ITEMS_X_OFFSET);

                if ((itemCoords[1] - ITEMS_RECTANGLE[1]) / ITEMS_Y_OFFSET >= 1)
                {
                    itemSlot += 4;
                }
            }

            return itemSlot;
        }
    }
}
