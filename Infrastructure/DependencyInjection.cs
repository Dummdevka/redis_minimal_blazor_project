using System;
using Application.Abstractions;
using Infrastructure.Caching;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DepedencyInjection
{
	public static IServiceCollection addInfrastructure(this IServiceCollection services) {
		
		return services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>()
						.AddSingleton<ICacheService, CacheService>();
	}
}

