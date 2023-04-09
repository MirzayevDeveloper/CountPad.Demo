// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Packages;

namespace CountPad.Application.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository packageRepository;

        public PackageService(IPackageRepository packageRepository) =>
            this.packageRepository = packageRepository;

        public async Task<int> AddPackageAsync(Package package) =>
            await this.packageRepository.AddAsync(package);

        public async Task<int> AddRangePackageAsync(IEnumerable<Package> packages)=>
            await this.packageRepository.AddRangeAsync(packages);

        public async Task<Package> GetPackageByIdAsync(Guid id) =>
            await this.packageRepository.GetByIdAsync(id);

        public async Task<List<Package>> GetAllPackageAsync()=>
            await this.packageRepository.GetAllAsync();

        public async Task<int> UpdatePackageAsync(Package package)=>
            await this.packageRepository.UpdateAsync(package);  

        public async Task<int> DeletePackageAsync(Guid id)=>
            await this.packageRepository.DeleteAsync(id);     
    }
}
