using Models.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductService
{
    public interface IProductService<T>
    {
        public  Task<IEnumerable<T>> Add(Product _object);
        public Task<IEnumerable<T>> Update(Product _object);
        public Task<IEnumerable<T>> Delete(int id);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
    }
}
