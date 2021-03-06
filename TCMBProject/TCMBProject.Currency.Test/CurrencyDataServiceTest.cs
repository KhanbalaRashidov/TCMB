using System;
using TCMBProject.Currency.Services;
using Xunit;

namespace TCMBProject.Currency.Test
{
    public class CurrencyDataServiceTest
    {
        private CurrencyDataService currencyService;
        public CurrencyDataServiceTest()
        {
            currencyService = new CurrencyDataService();
        }
        [Fact]
        public void Get_Today()
        {
            var result = currencyService.GetToday();
            Assert.True(result.Count > 0);
        }
        [Fact]
        public void Get_Currency_By_Date()
        {
            var result = currencyService.GetByDate(new DateTime(2021, 9, 7));
            Assert.True(result.Count > 0);
        }

    }
}
