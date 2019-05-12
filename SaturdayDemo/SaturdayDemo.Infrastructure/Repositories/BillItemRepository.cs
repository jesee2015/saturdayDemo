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
        public BillItemRepository(MyDbContext myDbContext)
        {
            MyDbContext = myDbContext;
        }

        public MyDbContext MyDbContext { get; }

        public void Add(BillItem billItem)
        {
            MyDbContext.BillItems.Add(billItem);
        }

        public async Task<IEnumerable<BillItem>> GetAllAsync()
        {
            return await MyDbContext.BillItems.ToListAsync();
        }

        public async Task<BillItem> GetByIdAsync(int id)
        {
            return await MyDbContext.BillItems.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task DeleteById(int id)
        {
            var billItem = await GetByIdAsync(id);
            MyDbContext.BillItems.Remove(billItem);
        }

        public async Task<IEnumerable<BillItem>> GetByDate(DateTime dateTime)
        {
            var date = dateTime.Date;
            return await MyDbContext.BillItems.Where(c => c.CreationDate.Date == date).ToListAsync();
        }
    }
}
