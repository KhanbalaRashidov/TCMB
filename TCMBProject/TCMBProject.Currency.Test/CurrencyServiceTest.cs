using System;
using TCMBProject.Currency.Services;
using Xunit;

namespace TCMBProject.Currency.Test
{
    public class CurrencyServiceTest
    {
        private CurrencyService currencyService;
        public CurrencyServiceTest()
        {
            currencyService = new CurrencyService();
        }
        [Fact]
        public async void Get_Today()
        {
            var result= await currencyService.GetToday();
            Assert.True(result.Count > 0);
        }
        [Fact]
        public async void Get_Currency_By_Date()
        {
            var result = await currencyService.GetByDate(new DateTime(2021, 9, 7));
            Assert.True(result.Count > 0);
        }

    }
}
