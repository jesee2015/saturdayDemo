using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SaturdayDemo.Core.entities;
using SaturdayDemo.Core.interfaces;
using SaturdayDemo.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaturdayDemo.Web.Controllers
{
    [Route("api/billitem")]
    public class BillItemController : Controller
    {
        public BillItemController(IBillItemRepository billItemRepository, IUnitOfWork unitOfWork)
        {
            BillItemRepository = billItemRepository;
            UnitOfWork = unitOfWork;
        }
        public IBillItemRepository BillItemRepository { get; }
        public IUnitOfWork UnitOfWork { get; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var billItems = await BillItemRepository.GetAllAsync();
            var strObjs = JsonConvert.SerializeObject(billItems);
            return Ok(billItems);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BillItem billItem)
        {
            //var billItem = new BillItem
            //{
            //    Market = "wanjia",
            //    ProductNoName = "308短袖",
            //    ProductNumber = 20,
            //    Shop = "2-3-5",
            //};
            BillItemRepository.Add(billItem);
            await UnitOfWork.SaveAsync(billItem);
            return Ok();
        }
    }
}
