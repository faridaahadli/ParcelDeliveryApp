using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Core.Enums
{
    public enum DeliveryStatus
    {
        Pending=1,
        Accepted,
        Going,
        Arrived,
        Canceled
    }
}
