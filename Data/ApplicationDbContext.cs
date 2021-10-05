using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OnlineShop_API.Models;

namespace OnlineShop_API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<ProductModel> product { get; set; }
        public DbSet<ProductTypeModel> productType { get; set; }
        public DbSet<OrderModel> orderModel { get; set; }
        public DbSet<OrderDetailsModel> orderDetailsModel { get; set; }
    }
}
