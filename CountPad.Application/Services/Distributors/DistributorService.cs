using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CountPad.Application.Abstactions;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Distributors;
using CountPad.Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            return await _context.AddAsync(distributor);
        }

        public async ValueTask<Distributor> DeleteDistributorAsync(Guid id)
        {
            Distributor maybeDistributor = await _context.GetAsync<Distributor>(id);

            if (maybeDistributor == null)
            {
                throw new ArgumentNullException(nameof(maybeDistributor));
            }

            return await _context.DeleteAsync(maybeDistributor);
        }

        public IQueryable<Distributor> GetAllDistributors()
        {
            return _context.GetAll<Distributor>();
        }

        public async ValueTask<Distributor> GetDistributorByIdAsync(Guid id)
        {
            return await _context.GetAsync<Distributor>(id);
        }

        public async ValueTask<Distributor> UpdateDistributorAsync(Distributor distributor)
        {
            return await _context.UpdateAsync<Distributor>(distributor);                                 
        
        }
    }
}
