using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCMBProject.API.Models.FilterParameters
{
    public abstract class RequestParameters
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public string SortedBy { get; set; } = "";
    }
}
