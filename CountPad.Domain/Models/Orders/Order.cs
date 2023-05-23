// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using CountPad.Domain.Models.Bases;
using CountPad.Domain.Models.Packages;
using CountPad.Domain.Models.Solds;

namespace CountPad.Domain.Models.Orders
{
	public class Order : BaseEntity
	{
		public Guid	PackageId { get; set; }
		public Package Package { get; set; }

        public Guid SoldId { get; set; }
        public Sold Sold { get; set; }
	}
}
