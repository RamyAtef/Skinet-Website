using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skinet.Core.Entities;
using Skinet.Core.Interfaces;

namespace Skinet.Infrastructure.Data
{
    public class ProductRepository:IProductRepository
    {
        public ProductRepository()
        {
            
        }
        public Task<Product> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Product>> GetProductsAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
