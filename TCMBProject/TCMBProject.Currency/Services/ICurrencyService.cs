using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCMBProject.Currency.Models;

namespace TCMBProject.Currency.Services
{
    public interface ICurrencyService
    {
        Task<CurrencyModel[]> GetToday();
        Task<CurrencyModel[]> GetByDate(DateTime date);
    }
}
