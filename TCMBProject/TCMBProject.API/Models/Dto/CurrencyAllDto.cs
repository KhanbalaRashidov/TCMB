using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCMBProject.API.Models.Dto
{
    public class CurrencyAllDto
    {
        public string CurrencyCode { get; set; }
        public string Name { get; set; }
        public string CrossRateUsd { get; set; }

    }
}
