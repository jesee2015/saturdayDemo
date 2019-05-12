using SaturdayDemo.Core.entities;
using SaturdayDemo.Core.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayDemo.Infrastructure.DataBase
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(MyDbContext myDbContext)
        {
            MyDbContext = myDbContext;
        }

        public MyDbContext MyDbContext { get; }

        public async Task<bool> SaveAsync(BaseEntity entity)
        {
            if (entity != null)
            {
                entity.CreationDate = DateTime.Now;
            }
            return await MyDbContext.SaveChangesAsync() > 0;
        }
    }
}
