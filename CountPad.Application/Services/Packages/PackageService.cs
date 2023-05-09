using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountPad.Application.Abstactions;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Packages;

namespace CountPad.Application.Services
{
    public class PackageService : IPackageService
    {
        private readonly IApplicationDbContext _context;

		public PackageService(IApplicationDbContext context)
		{
			_context = context;
		}

		public async ValueTask<Package> AddPackageAsync(Package package)
        {
            return await _context.AddAsync(package);
        }

        public ValueTask<Package> DeletePackageAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Package> GetAllPackageAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Package> GetPackageByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Package> UpdatePackageAsync(Package package)
        {
            throw new NotImplementedException();
        }
    }
}
