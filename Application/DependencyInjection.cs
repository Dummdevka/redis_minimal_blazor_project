using System;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
	public static IServiceCollection addApplication(this IServiceCollection services)
	{
		var assembly = typeof(DependencyInjection).Assembly;

		services.AddMediatR(configuration =>
			configuration.RegisterServicesFromAssembly(assembly)
		);
		return services;
	}
}

