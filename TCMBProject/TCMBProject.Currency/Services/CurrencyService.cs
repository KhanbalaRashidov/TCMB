using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TCMBProject.Currency.Models;
using TCMBProject.Currency.Serializer;
using RestSharp;

namespace TCMBProject.Currency.Services
{
    public class CurrencyService : ICurrencyService
    {
        private string urlPatter = "https://www.tcmb.gov.tr/kurlar/{0}.xml";

        private readonly ITCMBXmlSerailizer serailizer;

        public CurrencyService()
        {
            serailizer = new TCMBXmlSerializer();
        }
        public List<CurrencyModel> GetByDate(DateTime date)
        {
            var day = date.Day > 0 && date.Month < 10 ? $"0{date.Day}" : date.Day.ToString();
            var month = date.Month > 0 && date.Month < 10 ? $"0{date.Month}" : date.Month.ToString();
            var url = new Uri(string.Format(urlPatter, $"{date.Year}{month}/{day}{month}{date.Year}"));
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.Get<List<Tarih_Date>>(request);
            var deserialize = serailizer.Deserializer<Tarih_Date>(response.Content);
            var result = deserialize.Currency.Select(CurrencyModel.Map).ToList();
            return result;
        }

        public List<CurrencyModel> GetToday()
        {
            var url = new Uri(string.Format(urlPatter, "today"));
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.Get<List<Tarih_Date>>(request);
            var deserialize = serailizer.Deserializer<Tarih_Date>(response.Content);
            var result = deserialize.Currency.Select(CurrencyModel.Map).ToList();
            return result;
        }
    }
}
