using System;
using System.Collections.Generic;
using System.Text;
using ConvertCurrency.Infrastructure.Repositories;
using ConvertCurrency.Domain.Contracts.Services;
using System.Threading.Tasks;
using ConvertCurrency.Domain.Contracts.Repositories;
using ConvertCurrency.Domain.Model;

namespace ConvertCurrency.Services
{
    public class CurrencyServices: ICurrencyServices
    {
        private ICurrencyRepository _repository;
        public CurrencyServices(ICurrencyRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> ConvertCurrency(CurrenciesToConvert currencies)
        {
            CurrenciesToConvert toConv = new CurrenciesToConvert(currencies);
            toConv.Validation();
            decimal value = await _repository.Convert(currencies.value1, currencies.value2, currencies.amount);     
            return $"{currencies.currency2} = {String.Format("{0:N}", value)}";

        }

        public async Task<Dictionary<string, decimal>> GetAllCurrencies()
        {
            Dictionary<string, decimal> currencies;
            var response = await _repository.GetAllAsync();
            if (response != null)
            {
                currencies = new Dictionary<string, decimal>();
                currencies.Add("Real Brasileiro (BRL)", response.Quotes.USDBRL);
                currencies.Add("Peso Argentino(ARS)", response.Quotes.USDARS);
                currencies.Add("Euro Europa (EUR)", response.Quotes.USDEUR);
                currencies.Add("Iuane Chinês (CNY)", response.Quotes.USDCNY);
                currencies.Add("Iene japão (JPY)", response.Quotes.USDJPY);
                currencies.Add("Dólar Usa (USD)", 1.00M);
                return currencies;
            }
            else
                return null;
        }
    }
}
