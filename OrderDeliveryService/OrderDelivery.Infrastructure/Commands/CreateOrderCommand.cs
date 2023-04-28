using OrderDelivery.Core.Enums;
using OrderDelivery.Core.Interfaces.Commands;
using OrderDelivery.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Infrastructure.Commands
{
    public class CreateOrderCommand:ICommand<CreateOrderResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Status { get; set; } =(int) DeliveryStatus.Pending;
        public int DeliveryTypeId { get; set; }
        public int AuthorId { get; set; }
       
    }
}
