// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using CountPad.Application.Services.Products.Exceptions;
using CountPad.Application.Services.Products.Products.Exceptions;
using CountPad.Domain.Models.Products;

namespace CountPad.Application.Services
{
	public partial class ProductService
	{

		private static void ValidateProduct(Product product)
		{
			ValidateProductIsNotNull(product);


		}

		private static bool IsInvalid<T>(T value)
		{
			return IsEnumInvalid(value);
		}

		private static bool IsInvalid(Guid id)
		{
			return id != default;
		}

		private static bool IsInvalid(string text)
		{
			return !string.IsNullOrWhiteSpace(text);
		}

		private static bool IsEnumInvalid<T>(T value)
		{
			bool isDefined = Enum.IsDefined(typeof(T), value);

			return isDefined is false;
		}

		private static void Validate(bool[] conditions)
		{
			var invalidProductException = new InvalidProductException();

			foreach (bool condition in conditions)
			{
			}
		}

		private static void ValidateProductIsNotNull(Product product)
		{
			if (product == null)
			{
				throw new NullProductException();
			}
		}
	}
}
