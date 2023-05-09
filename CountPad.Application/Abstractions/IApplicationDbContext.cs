// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CountPad.Domain.Models.Distributors;
using CountPad.Domain.Models.Orders;
using CountPad.Domain.Models.Packages;
using CountPad.Domain.Models.Products;
using CountPad.Domain.Models.Solds;
using CountPad.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace CountPad.Application.Abstactions
{
	public interface IApplicationDbContext
	{
		public DbSet<Distributor> Distributors { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Package> Packages { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Sold> Solds { get; set; }
		public DbSet<User> Users { get; set; }

		public ValueTask<T> AddAsync<T>(T @object);
		public ValueTask<T> GetAsync<T>(params object[] objectIds) where T : class;
		public IQueryable<T> GetAll<T>() where T : class;
		public ValueTask<T> UpdateAsync<T>(T @object);
		public ValueTask<T> DeleteAsync<T>(T @object);

		public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
