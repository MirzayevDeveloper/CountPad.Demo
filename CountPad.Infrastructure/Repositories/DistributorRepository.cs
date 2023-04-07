using System;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Domain.Models.Distributors;

namespace CountPad.Infrastructure.Repositories
{
    public class DistributorRepository : BaseRepository, IDistributorRepository
    {

        public Task<int> AddAsync(Distributor entity)
        {
            throw new NotImplementedException();
        }
    }
}


