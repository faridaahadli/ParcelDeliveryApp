using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Infrastructure.Responses
{
    public class GetDeliveryResponse
    {
        public int CourierId { get; set; }
        public DateTime? ArriveDate { get; set; }
        public string? Comment { get; set; }
        public bool IsSuccess { get; set; }
    }
}
