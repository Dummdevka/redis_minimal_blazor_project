using System;
using System.Text.Json;
using Application.Abstractions;
using Microsoft.Extensions.Caching.Distributed;

namespace Infrastructure.Caching;

public class CacheService : ICacheService
{
	private readonly IDistributedCache _distributedCache;
	public CacheService(IDistributedCache distributedCache) 
	{
		_distributedCache = distributedCache;
	}

	public async Task<T?> GetRecordAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
	{
		string jsonValue = await _distributedCache.GetStringAsync(key, cancellationToken);

		if (jsonValue is null) {
			return null;
		}

		T? value = JsonSerializer.Deserialize<T>(jsonValue);

		return value;
	}

	public async Task SetRecordAsync<T>(string key,
	 T data,
	 TimeSpan? absoluteExpirationTime = null,
	 TimeSpan? unusedExpirationTime = null,
	 CancellationToken cancellationToken = default) where T : class
	{
		var options = new DistributedCacheEntryOptions();

		options.AbsoluteExpirationRelativeToNow = absoluteExpirationTime ?? TimeSpan.FromSeconds(60);
		options.SlidingExpiration = unusedExpirationTime;

		string record = JsonSerializer.Serialize(data);
		await _distributedCache.SetStringAsync(key, record, options);
	}
}

