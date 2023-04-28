using OrderDelivery.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Core.Entities
{
    public class Delivery:BaseEntity
    {
        
        public int CourierId { get; set; }
        public DateTime? ArriveDate { get; set; }
        public string? Comment { get; set; } 
        public bool IsSuccess { get; set; }
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
