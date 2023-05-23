// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using CountPad.Domain.Models.Bases;

namespace CountPad.Domain.Models.Products
{
	public class ProductCategory : BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
    }
}

