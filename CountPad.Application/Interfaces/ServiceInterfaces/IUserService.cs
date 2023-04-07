// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System.Threading.Tasks;
using CountPad.Domain.Models.Users;

namespace CountPad.Application.Interfaces.ServiceInterfaces
{
    public interface IUserService
    {
        Task<int> AddUserAsync(User user);
    }
}
