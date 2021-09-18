using OnlineShop_API.Data;
using System.Threading.Tasks;
using OnlineShop_API.IRepository;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using OnlineShop_API.Models;

namespace OnlineShop_API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<ProductModel>> getAllProduct()
        {
            return (await _db.product.Include(c => c.productType).ToListAsync());
        }

        public async Task<ProductModel> getOneProduct(int id)
        {
            return await _db.product.FindAsync(id);
        }

        public async Task addProduct(ProductModel product)
        {
            await _db.product.AddAsync(product);
            await _db.SaveChangesAsync();
        }

        public async Task editProduct(ProductModel product)
        {
            _db.product.Update(product);
            await _db.SaveChangesAsync();
        }

        public async Task deleteProduct(int id)
        {
            _db.product.Remove(await getOneProduct(id));
            await _db.SaveChangesAsync();
        }

        public async Task<List<ProductModel>> Search(string query)
        {
            return await _db.product.Include(c=>c.productType).Where(c => c.productName.Contains(query) || c.productType.type.Contains(query)).ToListAsync();
        }
    }
}
