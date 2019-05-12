using SaturdayDemo.Core.entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayDemo.Core.interfaces
{
    public interface IBillItemRepository
    {
        Task<BillItem> GetByIdAsync(int id);
        Task<IEnumerable<BillItem>> GetByDate(DateTime dateTime);
        Task<IEnumerable<BillItem>> GetAllAsync();
        void Add(BillItem billItem);
        Task DeleteById(int id);
    }
}
