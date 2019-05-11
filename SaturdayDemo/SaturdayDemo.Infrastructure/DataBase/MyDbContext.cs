using Microsoft.EntityFrameworkCore;
using SaturdayDemo.Core.entities;
using SaturdayDemo.Infrastructure.DataBase.EntityConfigurations;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BillItemConfiguration());
        }

        public DbSet<BillItem> BillItems { get; set; }
    }
}
