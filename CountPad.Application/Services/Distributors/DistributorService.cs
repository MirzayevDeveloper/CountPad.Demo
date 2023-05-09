using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CountPad.Application.Abstactions;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Distributors;

namespace CountPad.Application.Services
{
    public class DistributorService : IDistributorService
    {
        private readonly IApplicationDbContext _context;

        public DistributorService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async ValueTask<Distributor> AddDistributorAsync(Distributor distributor)
        {
            await _context.Distributors.AddAsync(distributor);
            await _context.SaveChangesAsync();
            return distributor;
        }

        public async ValueTask<Distributor> DeleteDistributorAsync(Guid id)
        {
            var entity = await _context.Distributors.FindAsync(id);

            _context.Distributors.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public IQueryable<Distributor> GetAllDistributors()
        {
            var  entities=_context.GetAll<Distributor>();
            return entities;
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
