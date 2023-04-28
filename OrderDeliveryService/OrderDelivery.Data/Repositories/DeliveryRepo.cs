using OrderDelivery.Core.Entities;
using OrderDelivery.Core.Interfaces.Repositories;
using OrderDelivery.Data.AppDbContext;
using OrderDelivery.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Data.Repositories
{
    public class DeliveryRepo:BaseRepo<Delivery>,IDeliveryRepo
    {
        private readonly ParcelDeliveryDb _context;
        public DeliveryRepo(ParcelDeliveryDb context) : base(context)
        {
            _context = context;
        }
    }

}
