using OnlineShop_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop_API.IRepository
{
    public interface IProductRepository
    {
        Task addProduct(ProductModel product);
        Task deleteProduct(int id);
        Task editProduct(ProductModel product);
        Task<List<ProductModel>> getAllProduct();
        Task<ProductModel> getOneProduct(int id);
        Task<List<ProductModel>> Search(string query);
        Task<List<ProductModel>> GetProByType(int id);
        Task<List<ProductTypeModel>> GetAllType();
    }
}