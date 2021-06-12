using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public class ApplicationDBContext : DbContext
    {
        private readonly string con;
        public ApplicationDBContext(string Connection)
        {
            con = Connection;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(con);
        }

        public DbSet<Product> Products { get; set; }
    }
}
