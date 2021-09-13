using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCMBProject.API.Data;
using TCMBProject.API.Repositories;
using TCMBProject.API.Services;
using TCMBProject.Currency.Models;
using TCMBProject.Currency.Services;

namespace TCMBProject.API.BgService
{
    public class TCMBAddedService : BackgroundService
    {
        private readonly ICurrencyDataService _currencyDataService;
        private readonly ICurrencyService _currencyService;
        private readonly IServiceScopeFactory _scopeFactory;
        private Timer timer;
        public TCMBAddedService(ICurrencyDataService currencyDataService, IServiceScopeFactory scopeFactory,
            ICurrencyService cuurencyService)
        {
            _currencyService = cuurencyService;
            _currencyDataService = currencyDataService;
            _scopeFactory = scopeFactory;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (DateTime.Now.Hour > 9 && DateTime.Now.Hour < 18)
            {

                timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(1));

            }
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<TCMBDbContext>();

            var todayData = CurrencyList();
            _currencyService.Add(dbContext, todayData);
            Console.WriteLine($"Added Currency {DateTime.Now.ToLongTimeString()}");
        }

        private  List<CurrencyModel> CurrencyList()
        {
            return  _currencyDataService.GetToday();
        }

    }
}
