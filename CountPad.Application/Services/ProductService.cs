using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountPad.Application.Abstactions;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Products;

namespace CountPad.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IApplicationDbContext _context;

		public ProductService(IApplicationDbContext context) =>
			_context = context;

		public ValueTask<Product> AddProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Product> DeleteProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Product> GetProductByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Product> UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
