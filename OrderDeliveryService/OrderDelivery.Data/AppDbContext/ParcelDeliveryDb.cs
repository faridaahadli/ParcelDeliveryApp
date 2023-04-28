using Microsoft.EntityFrameworkCore;
using OrderDelivery.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Data.AppDbContext
{
    public class ParcelDeliveryDb:DbContext
    {
        public ParcelDeliveryDb(DbContextOptions<ParcelDeliveryDb> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryType> DeliveryTypes { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Seed(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        private void Seed(ModelBuilder builder)
        {
            DeliveryType fastType = new DeliveryType() { Id=1,Name = "fast" };
            DeliveryType normalType = new DeliveryType() {Id=2, Name = "normal" };
            
            builder.Entity<DeliveryType>().HasData(fastType, normalType);
        }
    }
}
