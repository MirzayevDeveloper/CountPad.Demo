// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CountPad.Domain.Models.Distributors;

namespace CountPad.Application.Interfaces.ServiceInterfaces
{
    public interface IDistributorService
    {
        Task<int> AddDistributorAsync(Distributor distributor);
        Task<int> AddDistributorRangeAsync(IEnumerable<Distributor> distributors);
        Task<Distributor> GetDistributorByIdAsync(Guid id);
        Task<List<Distributor>> GetAllDistributors();
        Task<int> UpdateDistributorAsync(Distributor distributor);
        Task<int> DeleteDistributorAsync(Guid id);
    }
}

