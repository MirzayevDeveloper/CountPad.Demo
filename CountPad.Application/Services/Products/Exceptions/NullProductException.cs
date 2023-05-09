// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;

namespace CountPad.Application.Services.Products.Products.Exceptions
{
	public class NullProductException : Exception
	{
        public NullProductException() : base("Product is null.")
        { }
    }
}
