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

        public async Task<List<CurrencyModel>> GetAll(QueryParameters query)
        {

            var data = await _dbContext.Set<CurrencyModel>().ToListAsync();
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
           return data.ToList();
        }

        public async Task<List<CurrencyModel>> GetByCuurencyCode(string code)
        {
            var data = await _dbContext.CurrencyModels.Where(x => x.CurrencyCode == code).ToListAsync();
            return data;
        }


    }
}
