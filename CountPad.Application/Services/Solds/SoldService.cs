// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Solds;

namespace CountPad.Application.Services
{
	public class SoldService : ISoldService
	{
		public ValueTask<Sold> AddSoldAsync(Sold sold)
		{
			throw new NotImplementedException();
		}

		public ValueTask<Sold> DeleteSoldAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<Sold> GetAllSoldsAsync()
		{
			throw new NotImplementedException();
		}

		public ValueTask<Sold> GetSoldByIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public ValueTask<Sold> UpdateSoldAsync(Sold sold)
		{
			throw new NotImplementedException();
		}
	}
}
