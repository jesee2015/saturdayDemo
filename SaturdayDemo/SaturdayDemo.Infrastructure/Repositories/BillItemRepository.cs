using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaturdayDemo.Core.entities;
using SaturdayDemo.Core.interfaces;
using SaturdayDemo.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayDemo.Infrastructure.Repositories
{
    public class BillItemRepository : IBillItemRepository
    {
        public MyDbContext MyDbContext { get; }
        public BillItemRepository(MyDbContext myDbContext)
        {
            MyDbContext = myDbContext;
        }

        [HttpPost]
        public void Add(BillItem billItem)
        {
            billItem.CreationDate = DateTime.Now;
            MyDbContext.BillItems.Add(billItem);
        }

        public async Task<IEnumerable<BillItem>> GetAllAsync()
        {
            return await MyDbContext.BillItems.OrderByDescending(c => c.CreationDate).ToListAsync();
        }

        public async Task<BillItem> GetByIdAsync(int id)
        {
            return await MyDbContext.BillItems.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<BillItem>> GetByMonthAsync(int month)
        {
            return await MyDbContext.BillItems.Where(c => c.CreationDate.Month == month).OrderByDescending(c => c.CreationDate).ToListAsync();
        }

        public async Task DeleteById(int id)
        {
            var billItem = await GetByIdAsync(id);
            MyDbContext.BillItems.Remove(billItem);
        }

        public async Task<IEnumerable<BillItem>> GetByDateAsync(DateTime dateTime)
        {
            var date = dateTime.Date;
            return await MyDbContext.BillItems.Where(c => c.CreationDate.Date == date).OrderByDescending(c => c.CreationDate).ToListAsync();
        }

        public async Task EditbyId(BillItem billItem)
        {
            var oldBillItem = await GetByIdAsync(billItem.Id);
            oldBillItem.Market = billItem.Market;
            oldBillItem.Price = billItem.Price;
            oldBillItem.ProductNoName = billItem.ProductNoName;
            oldBillItem.ProductNumber = billItem.ProductNumber;
            oldBillItem.Shop = billItem.Shop;
            oldBillItem.UserId = billItem.UserId;
        }

        //public async<> Task GetAnalysisByMonth(int month)
        //{
        //    var billItems = await GetByMonthAsync(month);
        //    var Analysis = billItems.GroupBy(c => c.CreationDate.Date).Select(bill => new
        //    {
        //        date = bill.Key,
        //        num = bill.Sum(c => c.ProductNumber)
        //    }).ToList();
        //    return Analysis;
        //}
    }
}
