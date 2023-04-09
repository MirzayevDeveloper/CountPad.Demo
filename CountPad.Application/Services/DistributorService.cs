// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Distributors;

namespace CountPad.Application.Services
{
    public class DistributorService : IDistributorService
    {
        private readonly IDistributorRepository distributorRepository;

        public DistributorService(IDistributorRepository distributorRepository) =>
            this.distributorRepository = distributorRepository;

        public async Task<int> AddDistributorAsync(Distributor distributor)
        {
            return await this.distributorRepository.AddAsync(distributor);
        }

        public async Task<int> AddDistributorRangeAsync(IEnumerable<Distributor> distributors)
        {
            return await this.distributorRepository.AddRangeAsync(distributors);
        }

        public async Task<int> DeleteDistributorAsync(Guid id)
        {
            return await this.distributorRepository.DeleteAsync(id);
        }

        public async Task<List<Distributor>> GetAllDistributors()
        {
            return await this.distributorRepository.GetAllAsync();
        }

        public async Task<Distributor> GetDistributorByIdAsync(Guid id)
        {
            return await this.distributorRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateDistributorAsync(Distributor distributor)
        {
            return await this.distributorRepository.UpdateAsync(distributor);
        }
    }
}

