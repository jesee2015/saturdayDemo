using Microsoft.Extensions.Logging;
using SaturdayDemo.Core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayDemo.Infrastructure.DataBase
{
    public class MyDbContextSeed
    {
        public static async Task SeedAsync(MyDbContext myDbContext, ILoggerFactory loggerFactory, int retry = 0)
        {
            int retryForAvailability = retry;
            try
            {
                if (myDbContext.BillItems == null || myDbContext.BillItems.Count() == 0)
                {
                    myDbContext.BillItems.AddRange(new List<BillItem>
                {
                    new BillItem
                    {
                        CreationDate =DateTime.Now,
                        Market ="nancheng",
                        ProductNoName="208连衣裙",
                        ProductNumber=30,
                        Price=50,
                        Shop="3-1-32",
                    },
                    new BillItem
                    {
                        CreationDate =DateTime.Now,
                        Market ="南城",
                        ProductNoName="218T恤",
                        ProductNumber=20,
                        Price=48,
                        Shop="3-5-35",
                    },
                });
                    await myDbContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var logger = loggerFactory.CreateLogger<MyDbContextSeed>();
                    logger.LogError(e.Message);
                    await SeedAsync(myDbContext, loggerFactory, retryForAvailability);
                }
            }
        }
    }
}
