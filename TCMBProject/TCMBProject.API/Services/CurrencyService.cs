  using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCMBProject.API.Data;
using TCMBProject.API.Models.FilterParameters;
using TCMBProject.API.Repositories;
using TCMBProject.Currency.Models;

namespace TCMBProject.API.Services
{
    public class CurrencyService : ICurrencyService
    {
        private ICurrencyRepository _currencyRepository;
        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }
        public void Add(TCMBDbContext dbContext, List<CurrencyModel> currencies)
        {
            _currencyRepository.Add(dbContext, currencies);
        }

        public async Task<List<CurrencyModel>> GetAll(QueryParameters query)
        {
            var data=  _currencyRepository.GetAll().Result;
            if (query.Name != null)
            {
                data = data.Where(x => x.Name == query.Name).ToList();
            }
            if (query.Code != null)
            {
                data = data.Where(x => x.CurrencyCode == query.Code).ToList();
            }

            switch (query.SortedBy)
            {
                case "code_desc":
                    data = data.OrderByDescending(x => x.CurrencyCode).ToList();
                    break;
                case "rate":
                    data = data.OrderBy(x => x.CrossRateUsd).ToList();
                    break;

                case "rate_desc":
                    data = data.OrderByDescending(x => x.CrossRateUsd).ToList();
                    break;
                default:
                    data = data.OrderBy(x => x.CurrencyCode).ToList();
                    break;
            }
            return  data.ToList();
        }

        public async Task<List<CurrencyModel>> GetByCuurencyCode(string code)
        {
          return await _currencyRepository.GetByCuurencyCode(code);
        }
    }
}
