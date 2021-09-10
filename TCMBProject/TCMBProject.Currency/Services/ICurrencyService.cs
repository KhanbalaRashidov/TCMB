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
        List<CurrencyModel> GetToday();
        List<CurrencyModel> GetByDate(DateTime date);
    }
}
