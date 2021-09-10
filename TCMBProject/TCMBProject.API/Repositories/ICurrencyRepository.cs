using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCMBProject.API.Models.Dto;
using TCMBProject.Currency.Models;

namespace TCMBProject.API.Repositories
{
    public interface ICurrencyRepository
    {
        Task<List<CurrencyModel>> GetAll();
        Task<List<CurrencyModel>> GetByCuurencyCode(string code);
        Task Add();
    }
}
