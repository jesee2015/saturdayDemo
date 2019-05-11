using Microsoft.EntityFrameworkCore;
using SaturdayDemo.Core.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaturdayDemo.Infrastructure.DataBase
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<BillItem> BillItems { get; set; }
    }
}
