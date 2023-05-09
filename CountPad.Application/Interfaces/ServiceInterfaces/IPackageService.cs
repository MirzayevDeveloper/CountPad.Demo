// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountPad.Domain.Models.Packages;

namespace CountPad.Application.Interfaces.ServiceInterfaces
{
    public interface IPackageService
    {
        ValueTask<Package> AddPackageAsync(Package package);
        ValueTask<Package> GetPackageByIdAsync(Guid id);
        IQueryable<Package> GetAllPackageAsync();
        ValueTask<Package> UpdatePackageAsync(Package package);
        ValueTask<Package> DeletePackageAsync(Guid id);
    }
}
