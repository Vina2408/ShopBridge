using Models.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessUnits.ProductsUnitOfWork
{
    public interface IProductUnitOfWork
    {
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> AddNewProduct(AddProductModel product);
        Task<IEnumerable<Product>> UpdateProduct(UpdateProductModel product);
        Task<IEnumerable<Product>> DeleteProduct(int id);
    }
}
