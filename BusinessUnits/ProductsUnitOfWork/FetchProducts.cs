using Models.Products;
using ProductService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessUnits.ProductsUnitOfWork
{
    public class FetchProducts
    {
        private IProductService<Product> _service { get; set; }
        public FetchProducts(IProductService<Product> productService)
        {
            _service = productService;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _service.GetById(id);
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _service.GetAll();
        }
    }
}
