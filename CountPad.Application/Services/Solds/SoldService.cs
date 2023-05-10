// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using CountPad.Application.Abstactions;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Solds;

namespace CountPad.Application.Services
{
	public class SoldService : ISoldService
	{
		private readonly IApplicationDbContext _applicationDbContext;

		public SoldService(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public async ValueTask<Sold> AddSoldAsync(Sold sold)
		{
			return await _applicationDbContext.AddAsync(sold);
		}

		public IQueryable<Sold> GetAllSoldsAsync()
		{
			return _applicationDbContext.GetAll<Sold>();
		}

		public async ValueTask<Sold> GetSoldByIdAsync(Guid id)
		{
			return await _applicationDbContext.GetAsync<Sold>(id);
		}

		public async ValueTask<Sold> UpdateSoldAsync(Sold sold)
		{
			return await _applicationDbContext.UpdateAsync(sold);
		}

		public async ValueTask<Sold> DeleteSoldAsync(Guid id)
		{
			Sold maybeSold = await _applicationDbContext.GetAsync<Sold>(id);

			if (maybeSold == null)
			{
				throw new ArgumentNullException(nameof(maybeSold));
			}

			return await _applicationDbContext.DeleteAsync(maybeSold);
		}

	}
}
