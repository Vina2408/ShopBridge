using BusinessUnits.ProductsUnitOfWork;
using DAL;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Products;
using Moq;
using ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductUnitTest
{
    [TestClass]
    public class ProductCRUDTest
    {
        Mock<IRepository<Product>> MockRepository = new Mock<IRepository<Product>>();
        IEnumerable<Product> _productList = null;
        IProductService<Product> productService;
        public ProductCRUDTest()
        {
            productService = new ProductDBService(MockRepository.Object);
            List<Product> AllProducts = new List<Product>();
            AllProducts.Add(new Product
            {
                CreatedOn = DateTime.Now,
                Description = "Test Desc",
                Id = 1,
                IsActive = true,
                Name = "Test Name1",
                Price = 100
            });
            _productList = AllProducts;
        }
        
        [TestMethod]
        public async Task Test_Add_Product()
        {

            //Arrange
            AddProductModel addProductModel = new AddProductModel
            {
                Description = "Test Desc",
                IsActive = true,
                Name = "Test Item",
                Price = 100
            };

            MockRepository.Setup(x => x.Add(It.IsAny<Product>())).Returns(Task.FromResult(_productList));

            //Act
            IProductUnitOfWork Products = new ProductCRUD(productService);
            IEnumerable<Product> listProducts  = await Products.AddNewProduct(addProductModel);

            //Assert            
            Assert.IsNotNull(listProducts);
            Assert.AreEqual("Test Name1", listProducts.First().Name);
            Assert.IsTrue(listProducts.First().Price > 0);
        }

        [TestMethod]
        public async Task Test_All_Product()
        {

            //Arrange
            AddProductModel Product = new AddProductModel
            {
                Description = "Test Desc",
                IsActive = true,
                Name = "Test Item",
                Price = 100
            };

            MockRepository.Setup(x => x.GetAll()).Returns(Task.FromResult(_productList));

            //Act
            IProductUnitOfWork Products = new ProductCRUD(productService);
            IEnumerable<Product> listProducts = await Products.GetAllProducts();

            //Assert            
            Assert.IsNotNull(listProducts);
            Assert.AreEqual("Test Name1", listProducts.First().Name);
            Assert.IsTrue(listProducts.First().Price > 0);
        }

        [TestMethod]
        public async Task Test_Product_ById()
        {

            //Arrange
            int inputId = 1;
            Product ProductOutput = new Product
            {
                Description = "Test Desc",
                IsActive = true,
                Name = "Test Item",
                Price = 100
            };

            MockRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(ProductOutput));

            //Act
            IProductUnitOfWork Products = new ProductCRUD(productService);
            Product ProductsOutput = await Products.GetProductById(inputId);

            //Assert            
             
            Assert.AreEqual("Test Item", ProductsOutput.Name);
            Assert.IsTrue(ProductsOutput.Price > 0);
        }

        [TestMethod]
        public async Task Test_Product_Delete()
        {

            //Arrange
            int inputId = 1;
            Product ProductOutput = new Product
            {
                Description = "Test Desc",
                IsActive = true,
                Name = "Test Item",
                Price = 100
            };

            MockRepository.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult(_productList));

            //Act
            IProductUnitOfWork Products = new ProductCRUD(productService);
            IEnumerable<Product> listProducts = await Products.DeleteProduct(inputId);

            //Assert            
            Assert.IsNotNull(listProducts);
            Assert.AreEqual("Test Name1", listProducts.First().Name);
            Assert.IsTrue(listProducts.First().Price > 0);
        }

        [TestMethod]
        public async Task Test_Product_Update()
        {

            //Arrange             
            UpdateProductModel ProductInputput = new UpdateProductModel
            {
                Id = 1,
                Description = "Test Desc",
                IsActive = true,
                Name = "Test Item",
                Price = 100
            };

            MockRepository.Setup(x => x.Update(It.IsAny<Product>())).Returns(Task.FromResult(_productList));

            //Act
            IProductUnitOfWork Products = new ProductCRUD(productService);
            IEnumerable<Product> listProducts = await Products.UpdateProduct(ProductInputput);

            //Assert            
            Assert.IsNotNull(listProducts);
            Assert.AreEqual("Test Name1", listProducts.First().Name);
            Assert.IsTrue(listProducts.First().Price > 0);
        }
    }
}
