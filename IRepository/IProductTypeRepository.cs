using OnlineShop_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop_API.IRepository
{
    public interface IProductTypeRepository
    {
        Task addType(ProductTypeModel productType);
        Task deleteProductType(int id);
        Task editProductType(ProductTypeModel productType);
        Task<List<ProductTypeModel>> getAllProductType();
        Task<ProductTypeModel> getOneProductType(int id);
    }
}