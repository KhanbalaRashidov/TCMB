using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCMBProject.API.Models.Dto;
using TCMBProject.API.Models.FilterParameters;
using TCMBProject.API.Repositories;
using TCMBProject.API.Services;

namespace TCMBProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private ICurrencyService _cuurencyService;
        public CurrencyController(ICurrencyService cuurencyService)
        {
            _cuurencyService = cuurencyService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] QueryParameters query)
        {
            var data = _cuurencyService.GetAll(query).Result;
            var currenyAll = data.Select(x => new CurrencyAllDto
            {
                CurrencyCode = x.CurrencyCode,
                Name = x.Name,
                CrossRateUsd = x.CrossRateUsd,
            }).ToList();
            return Ok(currenyAll);
        }
        [HttpGet("GetByCode")]
        public IActionResult GetByCode(string code)
        {
            var data = _cuurencyService.GetByCuurencyCode(code).Result;
            if (data.Count == 0)
            {
                return NotFound();
            }
            var currencyHistories = data.Select(x => new CurrencyHistoryDto
            {
                CurrencyCode = x.CurrencyCode,
                AddedDate = x.AddDate,
                CrossRateUsd = x.CrossRateUsd,
            }).ToList();
            return Ok(currencyHistories);
        }
    }
}
