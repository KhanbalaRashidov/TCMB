using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCMBProject.API.Data;
using TCMBProject.API.Models.Dto;
using TCMBProject.API.Models.FilterParameters;
using TCMBProject.Currency.Models;
using TCMBProject.Currency.Services;

namespace TCMBProject.API.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {

        private TCMBDbContext _dbContext;

        public CurrencyRepository(IServiceProvider serviceProvider)
        {

            _dbContext = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<TCMBDbContext>();
        }

        public void Add(TCMBDbContext dbContext, List<CurrencyModel> currencies)
        {
            dbContext.CurrencyModels.AddRange(currencies);
            dbContext.SaveChanges();
        }

        public async Task<List<CurrencyModel>> GetAll()
        {
           return await _dbContext.Set<CurrencyModel>().ToListAsync();
        }

        public async  Task<List<CurrencyModel>> GetByCuurencyCode(string code)
        {
           return await _dbContext.CurrencyModels.Where(x => x.CurrencyCode == code).ToListAsync();
        }


    }
}
