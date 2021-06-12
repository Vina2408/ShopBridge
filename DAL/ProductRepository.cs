using Microsoft.Extensions.Configuration;
using Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductRepository : IRepository<Product>
    {

        ApplicationDBContext _dbContext;
        public ProductRepository(IConfiguration configuration)
        {
            _dbContext = new ApplicationDBContext(configuration["DefaultConnection"]);
        }
        public async Task<IEnumerable<Product>> Add(Product _object)
        {
            var newProd = new Product
            {
                Description = _object.Description,
                IsActive = _object.IsActive,
                Name = _object.Name,
                Price = _object.Price
            };
            await _dbContext.Products.AddAsync(newProd);
            _dbContext.SaveChanges();
            return  _dbContext.Products;
        }

        public async Task<IEnumerable<Product>> Delete(int id)
        {
            if (_dbContext.Products != null && _dbContext.Products.Count() > 0)
            {
                var delproduct = _dbContext.Products.Where(x => x.Id == id).FirstOrDefault();
                if (delproduct != null)
                {
                     _dbContext.Remove(delproduct);
                    _dbContext.SaveChanges();
                    return _dbContext.Products;
                }                
            }
            return null;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            if (_dbContext.Products != null && _dbContext.Products.Count() > 0)
            {
                return _dbContext.Products;
            }
            return null;
        }

        public async Task<Product> GetById(int id)
        {
            if (_dbContext.Products != null && _dbContext.Products.Count() > 0)
            {
                return _dbContext.Products.Where(x=> x.Id == id).FirstOrDefault();
            }
            return null;
        }

        public async Task<IEnumerable<Product>> Update(Product _object)
        {
            if (_dbContext.Products != null && _dbContext.Products.Count() > 0)
            {
                //var Updateproduct =  _dbContext.Products.Where(x=>x.Id == _object.Id).FirstOrDefault(); // Without Async this line to be enabled
                var Updateproduct = await _dbContext.Products.FindAsync(_object.Id);
                if (Updateproduct != null)
                {
                    // _dbContext.Products.Update(_object); if without Async call this line can be executed
                    Updateproduct.Name = _object.Name;
                    Updateproduct.Description = _object.Description;
                    Updateproduct.Price = _object.Price;
                    Updateproduct.IsActive = _object.IsActive;

                    await _dbContext.SaveChangesAsync();
                    return _dbContext.Products;
                }               
            }
            return null;
        }
    }
}
