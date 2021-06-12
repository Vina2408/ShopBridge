using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using BusinessUnits.ProductsUnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Products;

namespace ShopBridge.Controllers.Products
{
    [ExcludeFromCodeCoverage]
    [Authorize(Roles = "Admin")] //This controller actions(API's) only can be access by Admin roles. Set Header [Key, value] (Key-Authorization, value-Get the token by run the GetToken API first and bind it)
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductUnitOfWork _productUnitOfWork;
        public ProductsController(IProductUnitOfWork productUnitOfWork)
        {
            _productUnitOfWork = productUnitOfWork;
        }

        [HttpPost]
        [Route("AddNewProduct")]
        public async Task<IActionResult> AddNewProduct(AddProductModel product)
        {
            return Ok( await _productUnitOfWork.AddNewProduct(product).ConfigureAwait(false));
        }

        // [Authorize(Roles = "Admin")] //Want enable in the API method level, Just uncomment the attribute. And comment controller level Authorize attribute to make visible other API's for public
        [HttpGet]
        [Route("GetProductById")]
        public async Task<IActionResult> GetProductById([Required]int Id)
        {
            return Ok(await _productUnitOfWork.GetProductById(Id).ConfigureAwait(false));
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductModel product)
        {
            IEnumerable<Product> listProducts = await _productUnitOfWork.UpdateProduct(product).ConfigureAwait(false);
            if (listProducts != null)
                return Ok(listProducts);
            else
                return BadRequest("There is no data to update.!");
        }

        [HttpGet]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([Required]int Id)
        {
            IEnumerable<Product> listProducts = await _productUnitOfWork.DeleteProduct(Id).ConfigureAwait(false);
            if (listProducts != null)
                return Ok(listProducts);
            else
                return BadRequest("There is no data to delete.!");             
        }

        [HttpGet]
        [Route("GetAllproducts")]
        public async Task<IActionResult> GetAllproducts()
        {
            return Ok(await _productUnitOfWork.GetAllProducts().ConfigureAwait(false));
        }
    }
}