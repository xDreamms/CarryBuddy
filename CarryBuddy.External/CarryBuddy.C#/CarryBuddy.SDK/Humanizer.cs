using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryBuddy.SDK
{
    public class Humanizer
    {
        private static int _keyDelay = 1;
        public static int KeyDelay
        {
            get { return _keyDelay; }

            set
            {
                if (value > 0)
                {
                    _keyDelay = value;
                }
            }
        }
    }
}
