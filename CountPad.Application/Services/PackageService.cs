using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Packages;

namespace CountPad.Application.Services
{
    public class PackageService : IPackageService
    {
        public ValueTask<Package> AddPackageAsync(Package package)
        {
            throw new NotImplementedException();
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
