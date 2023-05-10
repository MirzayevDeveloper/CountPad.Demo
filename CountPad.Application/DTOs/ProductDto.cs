// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using CountPad.Domain.Models.Products;

namespace CountPad.Application.DTOs
{
	public class ProductDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public ProductTypes ProductType { get; set; }
		public string Description { get; set; }
	}
}
