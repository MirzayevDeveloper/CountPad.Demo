// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

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

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Distributor> Distributors { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Package> Packages { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Sold> Solds { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
