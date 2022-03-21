using System;

namespace Zoomo.Problem1
{
    public static class Util
    {
        public static bool IsStringNullOrEmpty(this string str)
        {
            return str == null || str == String.Empty;
        }
    }
}