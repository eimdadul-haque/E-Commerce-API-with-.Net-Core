using OnlineShop_API.Data;
using System.Threading.Tasks;
using OnlineShop_API.IRepository;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using OnlineShop_API.Models;
using OnlineShop_API.Servieces;
using Microsoft.AspNetCore.Hosting;

namespace OnlineShop_API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ProductRepository(ApplicationDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
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
            product.imageName = await HandleImageUploda.getImgObject().ImgHandel(product.productImg, _env);
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

        public async Task<List<ProductModel>> GetProByType(int id)
        {
            return await _db.product.Where(c => c.productTypeId == id).Include(c=>c.productType).ToListAsync();
        }

        public async Task<List<ProductTypeModel>> GetAllType()
        {
            return await _db.productType.ToListAsync();
        }

    }
}
