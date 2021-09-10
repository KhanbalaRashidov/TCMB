using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
       
        private TCMBDbContext _dbContext;

        public CurrencyRepository(IServiceProvider serviceProvider )
        {
            
            _dbContext = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<TCMBDbContext>();
        }

        public void Add(TCMBDbContext dbContext, List<CurrencyModel> currencies)
        {
            dbContext.Currencies.AddRange(currencies);
            dbContext.SaveChanges();
        }

        public  Task<List<CurrencyModel>>  GetAll() =>  _dbContext.Set<CurrencyModel>().ToListAsync();

        public  Task<List<CurrencyModel>> GetByCuurencyCode(string code)
        {
            var data =  _dbContext.Currencies.Where(x => x.CurrencyCode == code).ToListAsync();
            return data;
        }

        
    }
}
