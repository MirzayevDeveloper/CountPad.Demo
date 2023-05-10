// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using CountPad.Domain.Models.Packages;
using CountPad.Domain.Models.Solds;

namespace CountPad.Domain.Models.Orders
{
	public class Order
	{
		public Guid Id { get; set; }
		public Package Package { get; set; }
		public Sold Sold { get; set; }
	}
}
