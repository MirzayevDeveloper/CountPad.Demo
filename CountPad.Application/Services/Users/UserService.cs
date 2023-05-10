// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using CountPad.Application.Abstactions;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Users;

namespace CountPad.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IApplicationDbContext _applicationDbContext;

		public UserService(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public async ValueTask<User> AddUserAsync(User user)
			=> await _applicationDbContext.AddAsync(user);

		public async ValueTask<User> GetUserByIdAsync(Guid id)
			=> await _applicationDbContext.GetAsync<User>(id);

		public IQueryable<User> GetAllUsersAsync()
			=> _applicationDbContext.GetAll<User>();

		public async ValueTask<User> UpdateUserAsync(User user)
			=> await _applicationDbContext.UpdateAsync(user);

		public async ValueTask<User> DeleteUserAsync(Guid id)
		{
			User maybeUser = await _applicationDbContext.GetAsync<User>(id);

			if (maybeUser == null)
			{
				throw new ArgumentNullException(nameof(maybeUser));
			}

			return await _applicationDbContext.DeleteAsync(maybeUser);
		}
	}
}
