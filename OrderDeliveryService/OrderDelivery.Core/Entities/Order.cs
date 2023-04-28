using OrderDelivery.Core.Entities.Base;
using OrderDelivery.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Core.Entities
{
    public class Order:BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }=(int)DeliveryStatus.Pending;
        public virtual DeliveryType DeliveryType { get; set; }  
        public int DeliveryTypeId { get; set; }
        public int AuthorId { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }=new List<Delivery>();
    }
}
