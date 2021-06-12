using Models.Products;
using ProductService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessUnits.ProductsUnitOfWork
{
    public class AddProduct
    {
        private IProductService<Product> _service { get; set; }
        public AddProduct(IProductService<Product> productService)
        {
            _service = productService;
        }

        public async Task<IEnumerable<Product>> AddNewProduct(AddProductModel product)
        {
            Product addNewProduct = new Product
            {
                CreatedOn = DateTime.Now,
                Description = product.Description,
                IsActive = product.IsActive,
                Name = product.Name,
                Price = product.Price
            };
           return await _service.Add(addNewProduct);
        }
    }
}
