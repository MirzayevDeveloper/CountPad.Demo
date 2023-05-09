// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using CountPad.Application.Services.Products.Products.Exceptions;
using CountPad.Domain.Models.Products;

namespace CountPad.Application.Services
{
	public partial class ProductService
	{
		public static void ValidateProductIsNotNull(Product product)
		{
			if (product == null)
			{
				throw new NullProductException();
			}
		}
	}
}
