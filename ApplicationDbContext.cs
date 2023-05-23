using FinalMockProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalMockProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Order>()
                 .HasMany(o => o.OrderDetails)
                 .WithOne(od => od.Order)
                 .HasForeignKey(od => od.Order_Id);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderDetails)
                .WithOne(od => od.Product)
                .HasForeignKey(od => od.Product_Id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.User_Id);
            modelBuilder.Entity<Role>().HasData(
                 new Role
                 {
                     RoleId = 1,
                     RoleName = "Admin"
                 },

                 new Role
                 {
                     RoleId = 2,
                     RoleName = "User"
                 });


         }
            /*protected override void OnModelCreating(ModelBuilder modelBuilder)

            {
                modelBuilder.Entity<Role>().HasData(
                    new Role
                    {
                        RoleId = 1,
                        RoleName = "Admin"
                    },

                    new Role
                    {
                        RoleId = 2,
                        RoleName = "User"
                    });




            }*/
        }
    }




