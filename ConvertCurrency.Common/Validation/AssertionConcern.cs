using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertCurrency.Common.Validation
{
    public class AssertionConcern
    {
        public static void AssertArgumentEqualsZeroOrNull(decimal? object1, string message)
        {
            if (object1 == 0 || object1 == null)
            {
                throw new InvalidOperationException(message);
            }
        }
        public static void AssertArgumentNotEmpty(string stringValue, string message)
        {
            if (stringValue == null || stringValue.Trim().Length == 0)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}
