using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCMBProject.API.Data;
using TCMBProject.API.Models.Dto;
using TCMBProject.Currency.Models;
using TCMBProject.Currency.Services;

namespace TCMBProject.API.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private ICurrencyService _currencyService;
        private TCMBDbContext _dbContext;

        public CurrencyRepository(ICurrencyService currencyService, TCMBDbContext dbContext)
        {
            _currencyService = currencyService;
            _dbContext = dbContext;
        }

        public async Task Add()
        {
            var data=_currencyService.GetToday();
            await _dbContext.AddRangeAsync(data);
            await _dbContext.SaveChangesAsync();
          
        }

        public async Task<List<CurrencyModel>> GetAll()
        {
            return  _dbContext.Set<CurrencyModel>().ToList();
           
        }

        public async Task<List<CurrencyModel>> GetByCuurencyCode(string code)
        {
            var data= _dbContext.Currencies.Where(x => x.CurrencyCode == code);
            var currencyList=new List<CurrencyModel>();
            foreach (var currency in data)
            {
                currencyList.Add(currency);
            }
            return currencyList;
        }

        
    }
}
