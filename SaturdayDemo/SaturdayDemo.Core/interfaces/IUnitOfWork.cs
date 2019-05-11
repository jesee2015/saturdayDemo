using SaturdayDemo.Core.entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayDemo.Core.interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync(BaseEntity entity);
    }
}
