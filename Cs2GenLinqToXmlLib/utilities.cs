using System;
using System.Collections.Generic;
using System.Text;

namespace Cs2GenLinqToXmlLib
{
    public class utilities
    {
        public static string Formatstring(string received)
        {
            string result = received;
            result = result.Replace("&", "");
            result = result.Replace("\"", "");
            result = result.Replace("#", "");
            result = result.Replace("'", "");
            result = result.Replace("-", "");
            result = result.Replace("_", "");
            result = result.Replace("�", "c");
            result = result.Replace("^", "");
            result = result.Replace("@", "");
            result = result.Replace("�", "a");
            result = result.Replace(":", "");
            result = result.Replace("*", "");
            result = result.Replace("$", "");
            result = result.Replace("<", "");
            result = result.Replace(">", "");

            return result;
        }
    }
}
