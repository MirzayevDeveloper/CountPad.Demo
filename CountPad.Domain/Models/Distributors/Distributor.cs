// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using CountPad.Domain.Models.Bases;

namespace CountPad.Domain.Models.Distributors
{
	public class Distributor : BaseEntity
	{
		public string Name { get; set; }
		public string CompanyPhone { get; set; }
		public string DelivererPhone { get; set; }
	}
}