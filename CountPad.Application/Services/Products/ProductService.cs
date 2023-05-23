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
	public partial class ProductService : IProductService
	{
		private readonly IApplicationDbContext _context;

		public ProductService(IApplicationDbContext context)
		{
			_context = context;
		}

		public async ValueTask<Product> AddProductAsync(Product product)
		{
			ValidateProductIsNotNull(product);

			return await _context.AddAsync<Product>(product);
		}

		public IQueryable<Product> GetAllProducts()
		{
			return _context.GetAll<Product>();
		}

		public async ValueTask<Product> GetProductByIdAsync(Guid id)
		{
			return await _context.GetAsync<Product>(id);
		}

		public async ValueTask<Product> UpdateProductAsync(Product product)
		{
			return await _context.UpdateAsync<Product>(product);
		}

		public async ValueTask<Product> DeleteProductAsync(Guid id)
		{
			Product maybeProduct = await _context.GetAsync<Product>(id);

			if (maybeProduct == null)
			{
				throw new ArgumentNullException();
			}

			return await _context.DeleteAsync(maybeProduct);
		}
	}
}
