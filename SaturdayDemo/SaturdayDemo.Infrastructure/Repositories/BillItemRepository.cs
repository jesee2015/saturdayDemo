using Microsoft.EntityFrameworkCore;
using SaturdayDemo.Core.entities;
using SaturdayDemo.Core.interfaces;
using SaturdayDemo.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
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
    }
}
