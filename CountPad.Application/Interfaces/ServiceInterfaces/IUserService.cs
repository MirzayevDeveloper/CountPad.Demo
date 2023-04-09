// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using CountPad.Domain.Models.Users;

namespace CountPad.Application.Interfaces.ServiceInterfaces
{
    public interface IUserService
    {
        Task<int> AddUserAsync(User user);
        Task<int> AddRangeUserAsync(IEnumerable<User> users);
        Task<User> GetUserByIdAsync(Guid id);
        Task<List<User>> GetAllUsersAsync();
        Task<int> UpdateUserAsync(User user);
        Task<int> DeleteUserAsync(Guid id);
    }
}
