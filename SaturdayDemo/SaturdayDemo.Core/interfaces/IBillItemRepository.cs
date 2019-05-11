using SaturdayDemo.Core.entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayDemo.Core.interfaces
{
    public interface IBillItemRepository
    {
        Task<IEnumerable<BillItem>> GetAllAsync();
        void Add(BillItem billItem);
    }
}
