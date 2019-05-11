using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SaturdayDemo.Core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaturdayDemo.Web.Controllers
{
    [Route("api/cashflow")]
    public class CashFlowController : Controller
    {
        public CashFlowController(ICashFlowRepository cashFlowRepository, ICashFlowRepository cashFlowRepository2)
        {
            var id = cashFlowRepository.Id;
            var id2 = cashFlowRepository2.Id;
            CashFlowRepository = cashFlowRepository;
        }

        public ICashFlowRepository CashFlowRepository { get; }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("cashflow");
        }
    }
}
