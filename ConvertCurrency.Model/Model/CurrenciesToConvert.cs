using System;
using System.Collections.Generic;
using System.Text;
using ConvertCurrency.Common.Validation;

namespace ConvertCurrency.Domain.Model
{
    public class CurrenciesToConvert
    {
        public CurrenciesToConvert()
        {

        }
        public CurrenciesToConvert( CurrenciesToConvert currency)
        {
            this.currency1 = currency.currency1;
            this.currency2 = currency.currency2;
            this.value1 = currency.value1;
            this.value2 = currency.value2;
            this.amount = currency.amount;
        }
        public string currency1 { get; set; }
        public decimal value1 { get; set; }
        public string currency2 { get; set; }
        public decimal value2 { get; set; }
        public decimal amount { get; set; }

        public void Validation()
        {
            AssertionConcern.AssertArgumentNotEmpty(this.currency1, "Informe a moeda a ser convertida");
            AssertionConcern.AssertArgumentNotEmpty(this.currency2, "Informe a moeda de converção");
            AssertionConcern.AssertArgumentEqualsZeroOrNull(this.value1, "Valor da moeda a ser convertida não pode ser zero");
            AssertionConcern.AssertArgumentEqualsZeroOrNull(this.value2, "Valor da moeda de conversão não pode ser zero");
            AssertionConcern.AssertArgumentEqualsZeroOrNull(this.amount, "Quantidade não pode ser zero");
        }

    }
}
