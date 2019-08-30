using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryBuddy.SDK
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class CBEntryPoint : Attribute
    {
        public CBEntryPoint() { }

        public override string ToString()
        {
            return "CBEntryPoint";
        }
    }
}
