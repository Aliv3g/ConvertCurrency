using ConvertCurrency.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConvertCurrency.Domain.Contracts.Repositories
{
    public interface ICurrencyRepository
    {
        Task<decimal> Convert(decimal current, decimal toconv, decimal amount);
        Task<Currency> GetAllAsync();
    }
}
