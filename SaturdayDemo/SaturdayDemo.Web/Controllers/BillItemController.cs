using Microsoft.AspNetCore.Http;
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
        public IBillItemRepository BillItemRepository { get; }
        public IUnitOfWork UnitOfWork { get; }
        public BillItemController(IBillItemRepository billItemRepository, IUnitOfWork unitOfWork)
        {
            BillItemRepository = billItemRepository;
            UnitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //string conStr = Configuration["user:name"];
            //throw new Exception("xxxxxxxxxxx");
            var billItems = await BillItemRepository.GetAllAsync();
            BillItemList vm = new BillItemList();
            vm.BillItems = billItems;
            vm.totleNum = billItems.Sum(c => c.ProductNumber);
            vm.amount = billItems.Sum(c => c.ProductNumber * c.Price);
            return Ok(vm);
        }

        [HttpGet]
        [Route("GetbyDate")]
        public async Task<IActionResult> GetbyDate(DateTime dateTime)
        {
            var billItems = await BillItemRepository.GetByDateAsync(dateTime);
            BillItemList vm = new BillItemList();
            vm.BillItems = billItems;
            vm.totleNum = billItems.Sum(c => c.ProductNumber);
            vm.amount = billItems.Sum(c => c.ProductNumber * c.Price);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BillItem billItem)
        {
            if (billItem == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            BillItemRepository.Add(billItem);
            await UnitOfWork.SaveAsync();
            return Ok(new { Code = 200 });
        }
        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> DeleteById(int id)
        {
            if (id < 1)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            await BillItemRepository.DeleteById(id);
            await UnitOfWork.SaveAsync();
            return Ok(new { Code = 200 });
        }
        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> EditById(BillItem billItem)
        {
            if (billItem == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            await BillItemRepository.EditbyId(billItem);
            await UnitOfWork.SaveAsync();
            return Ok(new { Code = 200 });
        }

        [Route("GetAnalysisByMonth")]
        public async Task<IActionResult> GetAnalysisByMonth(int month)
        {
            if (month > 12 || month < 1)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            var billItems = await BillItemRepository.GetByMonthAsync(month);
            var Analysis = billItems.GroupBy(c => c.CreationDate.Date).Select(bill => new
            {
                date = bill.Key,
                num = bill.Sum(c => c.ProductNumber)
            }).ToList();
            return Ok(Analysis);
        }

    }
}
