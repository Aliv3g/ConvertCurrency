using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using ConvertCurrency.Domain.Contracts.Repositories;
using ConvertCurrency.Domain.Model;
using ConvertCurrency.Infrastructure.DataAccess;
using System.Threading.Tasks;
using System.Collections;
using System.Linq;

namespace ConvertCurrency.Infrastructure.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private AccessCurrencyApiLayer _accessApi;
        public CurrencyRepository()
        {
            _accessApi = new AccessCurrencyApiLayer();
        }
        public async Task<decimal> Convert(decimal current, decimal toconv, decimal amount)
        {
            return  ((1/current) * toconv)* amount ;

        }

        public async Task<Currency> GetAllAsync()
        {
            string Uri = _accessApi.GetUrl();
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(Uri))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var jsonCurrencies = await response.Content.ReadAsStringAsync();
                            var currencies = JsonConvert.DeserializeObject<Currency>(jsonCurrencies.ToString());
                            return currencies;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex )
            {

                throw ex;
            }
        }

    }
}
