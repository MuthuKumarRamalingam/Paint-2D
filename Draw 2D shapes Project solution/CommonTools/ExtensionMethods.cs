using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonTools
{
    public static class ExtensionMethods
    {
        public static bool IsNull(this object value)
        {
            return (value == null);
        }

        public static bool IsNotNull(this object value)
        {
            return !IsNull(value);
        }

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
