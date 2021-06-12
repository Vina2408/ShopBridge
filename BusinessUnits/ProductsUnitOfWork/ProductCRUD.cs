using Models.Products;
using ProductService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessUnits.ProductsUnitOfWork
{
    public class ProductCRUD : IProductUnitOfWork
    {
        private  IProductService<Product> _service { get; set; }
        public ProductCRUD(IProductService<Product> productService)
        {
            _service = productService;
        }          
        public async Task<IEnumerable<Product>> AddNewProduct(AddProductModel product)
        {
            AddProduct addProduct = new AddProduct(_service);
            return await addProduct.AddNewProduct(product);
        }

        public async Task<IEnumerable<Product>> DeleteProduct(int id)
        {
            DeleteProduct deleteProduct = new DeleteProduct(_service);
            return await deleteProduct.DeleteProductById(id);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            FetchProducts fetchProducts = new FetchProducts(_service);
            return await fetchProducts.GetAllProduct();
        }

        public async Task<Product> GetProductById(int id)
        {
            FetchProducts  fetchProducts = new FetchProducts(_service);
            return await fetchProducts.GetProductById(id);
        }

        public async Task<IEnumerable<Product>> UpdateProduct(UpdateProductModel product)
        {
            UpdateProduct updateProduct = new UpdateProduct(_service);
            return await updateProduct.UpdateProductByOtherDetails(product);
        }
    }
}
