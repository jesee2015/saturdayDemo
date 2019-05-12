using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SaturdayDemo.Core.entities;
using SaturdayDemo.Core.interfaces;
using SaturdayDemo.Infrastructure.DataBase;
using SaturdayDemo.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaturdayDemo.Web.Controllers
{
    [Route("api/billitem")]
    public class BillItemController : Controller
    {
        public BillItemController(IBillItemRepository billItemRepository, IUnitOfWork unitOfWork
            , ILogger<BillItemController> logger, IConfiguration configuration)
        {
            BillItemRepository = billItemRepository;
            UnitOfWork = unitOfWork;
            Logger = logger;
            Configuration = configuration;
        }
        public IBillItemRepository BillItemRepository { get; }
        public IUnitOfWork UnitOfWork { get; }
        public ILogger<BillItemController> Logger { get; }
        public IConfiguration Configuration { get; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            string conStr = Configuration["user:name"];
            //throw new Exception("xxxxxxxxxxx");
            var billItems = await BillItemRepository.GetAllAsync();
            BillItemList vm = new BillItemList();
            vm.BillItems = billItems;
            vm.totleNum = billItems.Sum(c => c.ProductNumber);
            vm.amount = billItems.Sum(c => c.ProductNumber * c.Price);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BillItem billItem)
        {
            BillItemRepository.Add(billItem);
            await UnitOfWork.SaveAsync(billItem);
            return Ok();
        }
        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await BillItemRepository.DeleteById(id);
            await UnitOfWork.SaveAsync(null);
            return Ok(new { Code = 200 });
        }
    }
}
