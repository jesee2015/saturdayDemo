using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaturdayDemo.Core.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaturdayDemo.Infrastructure.DataBase.EntityConfigurations
{
    public class BillItemConfiguration : IEntityTypeConfiguration<BillItem>
    {
        public void Configure(EntityTypeBuilder<BillItem> builder)
        {
            //builder.Property(c => c.Market).IsRequired().HasMaxLength(50);
            builder.Property(c => c.UserId).IsRequired();
        }
    }
}
