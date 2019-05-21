using ConvertCurrency.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConvertCurrency.Domain.Contracts.Services
{
    public interface ICurrencyServices
    {
        Task <Dictionary<string, decimal>> GetAllCurrencies();
        Task<string> ConvertCurrency(CurrenciesToConvert currencies);
    }
}
