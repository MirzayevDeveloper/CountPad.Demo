// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CountPad.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddScoped<IDistributorService, DistributorService>();
			services.AddScoped<IOrderService, OrderService>();
			services.AddTransient<IProductService, ProductService>();
			services.AddTransient<IPackageService, PackageService>();

			return services;
		}
	}
}
