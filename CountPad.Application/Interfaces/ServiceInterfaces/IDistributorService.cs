// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System.Threading.Tasks;
using CountPad.Domain.Models.Distributors;

namespace CountPad.Application.Interfaces.ServiceInterfaces
{
    public interface IDistributorService
    {
        Task<int> AddDistributorAsync(Distributor distributor);

    }
}

