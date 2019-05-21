using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConvertCurrency.Domain.Contracts.Services;
using ConvertCurrency.Domain.Model;
using System;

namespace ConvertCurrency.Test
{
    [TestClass]
    public class UnitTest1
    {
        
        private ICurrencyServices _service;
        public UnitTest1(ICurrencyServices service)
        {
            _service = service;
        }
        [TestMethod]
        public async void GetAll()
        {
            var currecies = await _service.GetAllCurrencies();
            foreach (var item in currecies)
            {
                Console.WriteLine(item);
            }
          
        }
        [TestMethod]
        public async void ConvertCurrency()
        {
            CurrenciesToConvert conv = new CurrenciesToConvert
            {
                currency1 = "Real Brasileiro (BRL)",
                value1 = 4.069296M,
                amount = 1,
                currency2 = "Euro Europa (EUR)",
                value2 = 0.89612M
            };
            var converted = await _service.ConvertCurrency(conv);
            Console.WriteLine(converted);

        }
    }
}
