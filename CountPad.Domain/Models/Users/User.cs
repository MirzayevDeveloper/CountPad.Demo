// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using CountPad.Domain.Models.Bases;

namespace CountPad.Domain.Models.Users
{
	public class User : BaseEntity
	{
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Password { get; set; }
	}
}
