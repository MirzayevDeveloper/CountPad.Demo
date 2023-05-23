// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using CountPad.Domain.Models.Bases;
using CountPad.Domain.Models.Users;

namespace CountPad.Domain.Models.Solds
{
	public class Sold : BaseEntity
	{
		public DateTime SoldDate { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
	}
}
