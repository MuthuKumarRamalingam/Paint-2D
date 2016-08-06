using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Line_draw
{
    public static class ExtensionMethods
    {
        public static bool IsNullorEmpty(this string value)
        {
            return (value == null || value == "");
        }

        public static bool IsNotNullorEmpty(this string value)
        {
            return !value.IsNullorEmpty();
        }

    }
}
