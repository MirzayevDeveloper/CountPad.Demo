// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using CountPad.Domain.Models.Users;

namespace CountPad.Domain.Models.Roles
{
	public class UserRole
	{
		public Guid Id { get; set; }

		public Guid UserId { get; set; }
		public User User { get; set; }

		public Guid RoleId { get; set; }
		public Role Role { get; set; }
	}
}
