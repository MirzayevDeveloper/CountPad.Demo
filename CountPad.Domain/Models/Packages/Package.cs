// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using CountPad.Domain.Models.Bases;
using CountPad.Domain.Models.Distributors;
using CountPad.Domain.Models.Products;

namespace CountPad.Domain.Models.Packages
{
	public class Package : BaseEntity
	{
		public Double Count { get; set; }
		public Decimal IncomingPrice { get; set; }
		public Decimal SalePrice { get; set; }
		public DateTime IncomingDate { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid DistributorId { get; set; }
        public Distributor Distributor { get; set; }
	}
}
