using System;
using System.Collections;

namespace CarryBuddy.SDK.Utilities
{
    public class Arrays
    {
        /// <summary>
        /// Creates a string that each line is an element of <paramref name="array"/>.
        /// </summary>
        /// 
        /// <param name="array">Array of any type.</param>
        /// 
        /// <returns>
        /// An empty string if <paramref name="array"/> is empty.
        /// Otherwise, returns a multiple line string where each line is
        /// an element of <paramref name="array"/>.
        /// </returns>

        public static string ToString(Array array)
        {
            string str = "";
            int length = array.Length;

            if (length >= 1)
            {
                str += array.GetValue(0);
                int i = 1;

                while (i < length)
                {
                    str += "\n" + array.GetValue(i);

                    i++;
                }
            }

            return str;
        }

        /// <summary>
        /// Traverses <paramref name="array1"/> checking if its elements are in
        /// <paramref name="array2"/>. The elements that are in both arrays are
        /// inserted in a new array that this functions returns.
        /// </summary>
        /// 
        /// <param name="array1">first array</param>
        /// <param name="array2">second array</param>
        /// 
        /// <returns>
        /// An array that contains all the elements that are at the same
        /// time in the first and the second array.
        /// </returns>

        public static ArrayList GetCommonValues(ArrayList array1, ArrayList array2)
        {
            ArrayList new_array = new ArrayList();
            int length1 = array1.Count;
            int i = 0;
            object element = 1;

            while (i < length1)
            {
                element = array1[i];

                if (array2.IndexOf(element) != -1 && !new_array.Contains(element))
                {
                    new_array.Add(element);
                }

                i++;
            }

            return new_array;
        }

        /// <summary>
        /// Traverses <paramref name="array"/> searching for its greatest element.
        /// 
        /// <param name="array">numeric array</param>
        /// 
        /// <returns>
        /// Returns 0 if <paramref name="array"/> is empty. Otherwise, returns
        /// its greatest element.
        /// </returns>

        public static int GetGreatestValue(int[] array)
        {
            int greatest = int.MinValue;

            if (array.Length >= 1)
            {
                greatest = array[0];

                foreach (int value in array)
                {
                    if (value > greatest)
                    {
                        greatest = value;
                    }
                }
            }

            return greatest;
        }
    }
}
