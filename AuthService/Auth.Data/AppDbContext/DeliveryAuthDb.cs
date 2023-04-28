using Auth.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Data.AppDbContext
{
    public class DeliveryAuthDb : DbContext
    {
        public DeliveryAuthDb(DbContextOptions<DeliveryAuthDb> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserToRole> UserToRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Seed(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }


        private void Seed(ModelBuilder builder)
        {
            Role adminRole = new Role() {Id=1, Name = "admin" };
            Role userRole = new Role() {Id=2, Name = "user" };
            Role courierRole = new Role() {Id=3, Name = "courier" };

            builder.Entity<Role>().HasData(adminRole, userRole, courierRole);
        }
    }
}
