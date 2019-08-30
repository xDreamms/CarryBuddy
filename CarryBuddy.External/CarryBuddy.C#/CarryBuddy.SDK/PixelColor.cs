using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryBuddy.SDK
{
    public class PixelColor
    {
        public byte red { get; set; }
        public byte green { get; set; }
        public byte blue { get; set; }
        public byte alpha { get; set; }

        public PixelColor(byte red, byte green, byte blue, byte alpha)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = alpha;
        }

        public PixelColor(byte red, byte green, byte blue) :
            this(red, green, blue, 0xFF)
        { }


        public override bool Equals(object obj)
        {
            return ToString().Equals(obj.ToString());
        }

        public override string ToString()
        {
            return string.Format("0x{0:X2}{1:X2}{2:X2}{3:X2}", red, green, blue, alpha);
        }
    }
}
