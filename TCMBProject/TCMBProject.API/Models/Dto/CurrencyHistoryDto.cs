using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCMBProject.API.Models.Dto
{
    public class CurrencyHistoryDto
    {
        public string CurrencyCode { get; set; }
        public DateTime AddedDate { get; set; }
        public string CrossRateUsd { get; set; }
    }
}
