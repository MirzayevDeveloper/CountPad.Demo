// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;

namespace CountPad.Domain.Models.Roles
{
	public class Role
	{
		public Guid Id { get; set; }
		public string RoleName { get; set; }
		
		public ICollection<UserRole> UserRoles { get; set; }
		public ICollection<RolePermission> RolePermissions { get; set; }
	}
}
