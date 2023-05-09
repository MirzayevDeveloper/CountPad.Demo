using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Distributors;

namespace CountPad.Application.Services
{
    public class DistributorService : IDistributorService
    {
        public ValueTask<Distributor> AddDistributorAsync(Distributor distributor)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Distributor> DeleteDistributorAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Distributor> GetAllDistributors()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Distributor> GetDistributorByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Distributor> UpdateDistributorAsync(Distributor distributor)
        {
            throw new NotImplementedException();
        }
    }
}
