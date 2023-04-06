// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Packages;

namespace CountPad.Application.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository packageRepository;

        public PackageService(IPackageRepository packageRepository)=>
            this.packageRepository = packageRepository;
        
        public async Task<int> AddPackageAsync(Package package)=>
            await this.packageRepository.AddAsync(package);
    }
}
