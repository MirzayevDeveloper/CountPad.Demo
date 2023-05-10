// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;

namespace CountPad.Application.Services.Products.Exceptions
{
	public class InvalidProductException : Exception
	{
		public InvalidProductException()
			: base("Product is invalid, try again later!")
		{ }
	}
}
