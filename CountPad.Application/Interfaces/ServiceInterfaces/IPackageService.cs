// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System.Threading.Tasks;
using CountPad.Domain.Models.Packages;

namespace CountPad.Application.Interfaces.ServiceInterfaces
{
    public interface IPackageService
    {
        Task<int> AddPackageAsync(Package package);
    }
}
