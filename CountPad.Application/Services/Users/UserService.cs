// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Users;

namespace CountPad.Application.Services
{
	public class UserService : IUserService
	{
		public ValueTask<User> AddUserAsync(User user)
		{
			throw new NotImplementedException();
		}

		public ValueTask<User> DeleteUserAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<User> GetAllUsersAsync()
		{
			throw new NotImplementedException();
		}

		public ValueTask<User> GetUserByIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public ValueTask<User> UpdateUserAsync(User user)
		{
			throw new NotImplementedException();
		}
	}
}
