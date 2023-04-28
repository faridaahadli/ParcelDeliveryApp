using OrderDelivery.Core.Interfaces.Commands;
using OrderDelivery.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Infrastructure.Commands
{
    public class CreateDeliveryCommand:ICommand<CreateDeliveryResponse>
    {
        public int CourierId { get; set; }
        public string? Comment { get; set; }
        public int OrderId { get; set; }
    }
}
