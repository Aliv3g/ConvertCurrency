using System;
using System.Collections.Generic;
using System.Text;
using ConvertCurrency.Common.Helpful;

namespace ConvertCurrency.Infrastructure.DataAccess
{
    public class AccessCurrencyApiLayer
    {
       private const string key = "7cc81cfe1dc96412834a52c363bfd35c";
       private const string url = "http://apilayer.net/api/live";
       private readonly string[] currencies = {"EUR,ARS,BRL,JPY,CNY"}; 

        public string GetUrl()
        {
            string arrayCurrency = Converters.ConvertStringArrayToString(currencies);
            return $"{url}?access_key={key}&currencies={arrayCurrency}&source=USD&format=1";
        }
    }
}
