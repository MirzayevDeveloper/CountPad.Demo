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
			services.AddScoped<IProductService, ProductService>();

			return services;
		}
	}
}
