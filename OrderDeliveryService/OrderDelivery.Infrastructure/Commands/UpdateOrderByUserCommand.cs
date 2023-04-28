﻿using OrderDelivery.Core.Interfaces.Commands;
using OrderDelivery.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Infrastructure.Commands
{
    public class UpdateOrderByUserCommand:ICommand<CreateOrderResponse>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; } 
        public bool IsCanceled { get; set; }
    }
}
