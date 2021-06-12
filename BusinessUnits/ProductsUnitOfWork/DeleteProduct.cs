using Models.Products;
using ProductService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessUnits.ProductsUnitOfWork
{
    public class DeleteProduct
    {
        private IProductService<Product> _service { get; set; }
        public DeleteProduct(IProductService<Product> productService)
        {
            _service = productService;
        }

        public async Task<IEnumerable<Product>> DeleteProductById(int id)
        {
            return await _service.Delete(id);
        }
    }
}
