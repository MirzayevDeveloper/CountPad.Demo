// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Linq;
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

		public async ValueTask<Product> AddProductAsync(Product product)
		{
			return await _context.AddAsync(product);
		}

		public async ValueTask<Product> DeleteProductAsync(Guid id)
		{
			Product maybeProduct = await _context.GetAsync<Product>(id);

			if(maybeProduct == null)
			{
				throw new ArgumentNullException();
			}

			return await _context.DeleteAsync(maybeProduct);
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
