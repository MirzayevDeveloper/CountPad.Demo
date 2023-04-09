// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CountPad.Domain.Models.Packages;

namespace CountPad.Application.Interfaces.ServiceInterfaces
{
    public interface IPackageService
    {
        Task<int> AddPackageAsync(Package package);
        Task<int> AddRangePackageAsync(IEnumerable<Package> packages);
        Task<Package> GetPackageByIdAsync(Guid guid);
        Task<List<Package>> GetAllPackageAsync();
        Task<int> UpdatePackageAsync(Package package);
        Task<int> DeletePackageAsync(Guid guid);
    }
}
