// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using CountPad.Application.Abstactions;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Distributors;

namespace CountPad.Application.Services
{
    public class DistributorService : IDistributorService
    {
        private readonly IApplicationDbContext _context;

        public DistributorService(IApplicationDbContext context)=>
            _context = context;

        public async ValueTask<Distributor> AddDistributorAsync(Distributor distributor)=>
             await _context.AddAsync(distributor);

        public IQueryable<Distributor> GetAllDistributors()=>
             _context.GetAll<Distributor>();

        public async ValueTask<Distributor> GetDistributorByIdAsync(Guid id)=>
             await _context.GetAsync<Distributor>(id);

        public async ValueTask<Distributor> UpdateDistributorAsync(Distributor distributor)=>
            await _context.UpdateAsync<Distributor>(distributor);   
        
        public async ValueTask<Distributor> DeleteDistributorAsync(Guid id)
        {
            Distributor maybeDistributor = await _context.GetAsync<Distributor>(id);

            if (maybeDistributor == null)
            {
                throw new ArgumentNullException(nameof(maybeDistributor));
            }

            return await _context.DeleteAsync(maybeDistributor);
        }
    }
}
