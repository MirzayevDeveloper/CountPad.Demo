// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

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
    }
}

