// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using CountPad.Application.Abstactions;
using CountPad.Domain.Models.Distributors;
using CountPad.Domain.Models.Orders;
using CountPad.Domain.Models.Packages;
using CountPad.Domain.Models.Products;
using CountPad.Domain.Models.Solds;
using CountPad.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace CountPad.Infrastructure.Persistence
{
	public class ApplicationDbContext : DbContext, IApplicationDbContext
	{
		private readonly ApplicationDbContext _context;
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
			_context = new ApplicationDbContext(options);
		}

		public DbSet<Distributor> Distributors { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Package> Packages { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Sold> Solds { get; set; }
		public DbSet<User> Users { get; set; }

		public async ValueTask<T> AddAsync<T>(T @object)
		{
			_context.Entry(@object).State = EntityState.Added;
			await _context.SaveChangesAsync();

			return @object;
		}

		public async ValueTask<T> GetAsync<T>(params object[] objectIds) where T : class
		{
			return await _context.FindAsync<T>(objectIds);
		}

		public IQueryable<T> GetAll<T>() where T : class
		{
			return _context.Set<T>();
		}

		public async ValueTask<T> UpdateAsync<T>(T @object)
		{
			_context.Entry(@object).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return @object;
		}

		public async ValueTask<T> DeleteAsync<T>(T @object)
		{
			_context.Entry(@object).State = EntityState.Deleted;
			await _context.SaveChangesAsync();

			return @object;
		}
	}
}
