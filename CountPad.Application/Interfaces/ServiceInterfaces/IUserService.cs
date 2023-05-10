// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using CountPad.Domain.Models.Users;

namespace CountPad.Application.Interfaces.ServiceInterfaces
{
	public interface IUserService
	{
		ValueTask<User> AddUserAsync(User user);
		ValueTask<User> GetUserByIdAsync(Guid id);
		IQueryable<User> GetAllUsersAsync();
		ValueTask<User> UpdateUserAsync(User user);
		ValueTask<User> DeleteUserAsync(Guid id);
	}
}
