using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCMBProject.Currency.Models
{
    
    public class CurrencyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Unit { get; set; }
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public string CrossRateUsd { get; set; }
        public decimal ForexBuying { get; set; }
        public string ForexSelling { get; set; }
        public string BanknoteBuying { get; set; }
        public string BanknoteSelling { get; set; }

        public static CurrencyModel Map(Tarih_DateCurrency dateCurrency)
        {
            return new CurrencyModel
            {
                Unit = dateCurrency.Unit,
                Name = dateCurrency.CurrencyName,
                CurrencyCode = dateCurrency.CurrencyCode,
                BanknoteSelling = dateCurrency.BanknoteSelling,
                BanknoteBuying = dateCurrency.BanknoteBuying,
                ForexBuying = dateCurrency.ForexBuying,
                ForexSelling = dateCurrency.ForexSelling,
                CrossRateUsd = dateCurrency.CrossRateUSD
            };
        }
    }
}
