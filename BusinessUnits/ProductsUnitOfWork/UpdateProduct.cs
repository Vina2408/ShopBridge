using Models.Products;
using ProductService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessUnits.ProductsUnitOfWork
{
   public class UpdateProduct
    {
        private IProductService<Product> _service { get; set; }
        public UpdateProduct(IProductService<Product> productService)
        {
            _service = productService;
        }

        public async Task<IEnumerable<Product>> UpdateProductByOtherDetails(UpdateProductModel product)
        {
            Product updateInput = new Product
            {
                Description = product.Description,
                Id = (int)product.Id,
                IsActive = product.IsActive,
                Name = product.Name,
                Price = product.Price
            };
            return await _service.Update(updateInput);
        }
    }
}
