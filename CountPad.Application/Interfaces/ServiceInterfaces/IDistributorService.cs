// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountPad.Domain.Models.Distributors;

namespace CountPad.Application.Interfaces.ServiceInterfaces
{
    public interface IDistributorService
    {

        ValueTask<Distributor> AddDistributorAsync(Distributor distributor);
        ValueTask<Distributor> GetDistributorByIdAsync(Guid id);
        IQueryable<Distributor> GetAllDistributors();
        ValueTask<Distributor> UpdateDistributorAsync(Distributor distributor);
        ValueTask<Distributor> DeleteDistributorAsync(Guid id);
    }
}

