using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Models;
using Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService
{
    public class ProductORMService : IProductService<Product>
    {
        private string ConnString { get; set; }
        public ProductORMService(IOptions<ConfigurationOptionsModel> options)
        {
            ConnString = options.Value.DefaultConnection;
        }
        public async Task<IEnumerable<Product>> Add(Product _object)
        {
            IEnumerable<Product> AllProducts; 
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                int isActive = _object.IsActive ? 1 : 0;
                string sqlQuery = "INSERT INTO Products VALUES('" + _object.Name + "','" + _object.Description + "'," + _object.Price + ",'" + _object.CreatedOn + "',"+ isActive+")"; //Here implemented the Dapper ORM
                connection.Execute(sqlQuery);
                AllProducts = await connection.QueryAsync<Product>("SELECT * FROM Products");  
            }
            return AllProducts;
        }

        public async Task<IEnumerable<Product>> Delete(int id)
        {
            IEnumerable<Product> AllProducts;
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                string sqlQuery = "Delete from Products where id = " + id;
                connection.Execute(sqlQuery);
                AllProducts = await connection.QueryAsync<Product>("SELECT * FROM Products");
            }
            return AllProducts;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            IEnumerable<Product> AllProducts;
            using (SqlConnection connection = new SqlConnection(ConnString))
            {               
                AllProducts = await connection.QueryAsync<Product>("SELECT * FROM Products");
            }
            return AllProducts;
        }

        public async Task<Product> GetById(int id)
        {
            IEnumerable<Product> AllProducts;
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                string sqlQuery = "SELECT * FROM Products where id = " + id;
                AllProducts = await connection.QueryAsync<Product>(sqlQuery);
            }
            return AllProducts?.FirstOrDefault();
        }

        public async Task<IEnumerable<Product>> Update(Product _object)
        {
            IEnumerable<Product> AllProducts;
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                int isActive = _object.IsActive ? 1 : 0;
                string sqlQuery = "Update Products SET name = '" + _object.Name +"',description = '"+ _object.Description +"',Price="+ _object.Price+",isActive="+ isActive + " where id = "+ _object.Id;
                connection.Execute(sqlQuery);
                AllProducts = await connection.QueryAsync<Product>("SELECT *  FROM Products");
            }
            return AllProducts;
        }
    }
}
