using DAL;
using Models.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductService
{
    public class ProductDBService : IProductService<Product>
    {
        private readonly IRepository<Product> _repository;
        public ProductDBService(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Product>> Add(Product _object)
        {
            return await _repository.Add(_object);
        }

        public async Task<IEnumerable<Product>> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Product> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Product>> Update(Product _object)
        {
            return await _repository.Update(_object);
        }
    }
}
