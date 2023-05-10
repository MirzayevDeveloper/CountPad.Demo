// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Linq;
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

		public async ValueTask<Package> DeletePackageAsync(Guid id)
		{
			Package maybePackage = await _context.GetAsync<Package>(id);

			return await _context.DeleteAsync<Package>(maybePackage);
		}

		public IQueryable<Package> GetAllPackageAsync()
		{
			return _context.GetAll<Package>();
		}

		public async ValueTask<Package> GetPackageByIdAsync(Guid id)
		{
			return await _context.GetAsync<Package>(id);
		}

		public async ValueTask<Package> UpdatePackageAsync(Package package)
		{
			return await _context.UpdateAsync<Package>(package);
		}
	}
}
