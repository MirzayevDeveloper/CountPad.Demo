// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;

namespace CountPad.Application.Interfaces.RepositoryInterfaces
{
	public interface IRepository<T>
	{
		ValueTask<T> AddAsync(T entity);
		ValueTask<T> GetByIdAsync(Guid id);
		IQueryable<T> GetAllAsync();
		ValueTask<T> UpdateAsync(T entity);
		ValueTask<T> DeleteAsync(Guid id);
	}
}

