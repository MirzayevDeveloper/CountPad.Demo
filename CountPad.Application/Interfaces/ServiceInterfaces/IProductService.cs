// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using CountPad.Domain.Models.Products;

namespace CountPad.Application.Interfaces.ServiceInterfaces
{
	public interface IProductService
	{
		ValueTask<Product> AddProductAsync(Product product);
		ValueTask<Product> GetProductByIdAsync(Guid id);
		IQueryable<Product> GetAllProducts();
		ValueTask<Product> UpdateProductAsync(Product product);
		ValueTask<Product> DeleteProductAsync(Guid id);
	}
}

