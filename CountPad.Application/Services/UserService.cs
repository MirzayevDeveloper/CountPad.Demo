// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Users;

namespace CountPad.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository) =>
           this.userRepository = userRepository;

        public Task<int> AddUserAsync(User user) =>
            this.userRepository.AddAsync(user);

        public Task<int> AddRangeUserAsync(IEnumerable<User> users)=>
            this.userRepository.AddRangeAsync(users);

        public Task<List<User>> GetAllUsersAsync()=>
            this.userRepository.GetAllAsync();

        public Task<User> GetUserByIdAsync(Guid id)=>
            this.userRepository.GetByIdAsync(id);

        public Task<int> UpdateUserAsync(User user)=>
            this.userRepository.UpdateAsync(user);

        public Task<int> DeleteUserAsync(Guid id)=>
            this.userRepository.DeleteAsync(id);
    }
}
