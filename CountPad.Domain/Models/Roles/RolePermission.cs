// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;

namespace CountPad.Domain.Models.Roles
{
	public class RolePermission
	{
		public Guid Id { get; set; }

		public Guid RoleId { get; set; }
		public Role Role { get; set; }

		public Guid PermissionId { get; set; }
		public Permission Permission { get; set; }
	}
}
