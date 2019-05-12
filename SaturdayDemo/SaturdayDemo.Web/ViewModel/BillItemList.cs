using SaturdayDemo.Core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaturdayDemo.Web.ViewModel
{
    public class BillItemList
    {
        public IEnumerable<BillItem> BillItems { get; set; }
        public int totleNum { get; set; }
        public float amount { get; set; }
    }
}
