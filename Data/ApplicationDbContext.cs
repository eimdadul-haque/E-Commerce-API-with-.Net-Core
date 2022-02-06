using Microsoft.EntityFrameworkCore;
using OnlineShop_API.Models;

namespace OnlineShop_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<ProductModel> productD { get; set; }
    }
}
