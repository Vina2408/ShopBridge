using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T>
    {
        public  Task<IEnumerable<T>> Add(T _object);
        public Task<IEnumerable<T>> Update(T _object);
        public Task<IEnumerable<T>> Delete(int id);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
    }
}
