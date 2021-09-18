using OnlineShop_API.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineShop_API.IRepository;
using OnlineShop_API.Models;

namespace OnlineShop_API.Repository
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<ProductTypeModel>> getAllProductType()
        {
            return (await _db.productType.ToListAsync());
        }

        public async Task<ProductTypeModel> getOneProductType(int id)
        {
            return await _db.productType.FindAsync(id);
        }

        public async Task addType(ProductTypeModel productType)
        {
            await _db.productType.AddAsync(productType);
            await _db.SaveChangesAsync();
        }

        public async Task editProductType(ProductTypeModel productType)
        {
            _db.productType.Update(productType);
            await _db.SaveChangesAsync();
        }

        public async Task deleteProductType(int id)
        {
            _db.productType.Remove(await getOneProductType(id));
            await _db.SaveChangesAsync();
        }

    }
}
