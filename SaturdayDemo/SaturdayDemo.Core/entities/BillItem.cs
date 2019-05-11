using System;
using System.Collections.Generic;
using System.Text;

namespace SaturdayDemo.Core.entities
{
    public class BillItem : BaseEntity
    {
        public string Market { get; set; }
        public string Shop { get; set; }
        public string ProductNoName { get; set; }
        public int ProductNumber { get; set; }
        public int UserId { get; set; }
    }
}
