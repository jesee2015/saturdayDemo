using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaturdayDemo.Web.Controllers
{
    [Route("api/billitem")]
    public class BillItemController : Controller
    {
        public IActionResult Get()
        {
            return Ok("asdf");
        }
    }
}
