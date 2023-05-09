// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CountPad.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddMediatR(x => x.RegisterServicesFromAssembly(assembly: Assembly.GetExecutingAssembly()));

			return services;
		}
	}
}
