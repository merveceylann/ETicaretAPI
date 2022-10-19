using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
            => new() //target type, tekrar product demeye gerek yok
            {
                new() { Id = Guid.NewGuid(), Name = "Product 1", Stock = 10, Price = 100},
                new() { Id = Guid.NewGuid(), Name = "Product 2", Stock = 20, Price = 200},
                new() { Id = Guid.NewGuid(), Name = "Product 3", Stock = 30, Price = 300},
                new() { Id = Guid.NewGuid(), Name = "Product 4", Stock = 40, Price = 400}
            };
    }
}

