using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConvertCurrency.Domain.Model
{
    public class Currency
    {
        public bool Success { get; set; }
        public string Terms { get; set; }
        public string Privacy { get; set; }
        public long Timestamp { get; set; }
        public string Source { get; set; }
        public Quote Quotes { get; set; }
        //public List<Quote> quotes { get; set; }


    }
}
