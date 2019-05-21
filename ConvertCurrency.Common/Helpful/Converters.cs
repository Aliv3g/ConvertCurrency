using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConvertCurrency.Common.Helpful
{
    public static class Converters
    {
        private static CultureInfo provider = new CultureInfo("pt-BR");
        public static string ConvertStringArrayToString(string[] array)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value);
                builder.Append(',');
            }
            return builder.ToString();
        }
    }
}
