using System;
namespace Application.Abstractions
{
	public interface ICacheService
	{
		Task<T?> GetRecordAsync<T> (string key, CancellationToken cancellationToken = default) where T : class;

		Task SetRecordAsync<T>(string key, T data, TimeSpan? absoluteExpirationTime = null,
	 TimeSpan? unusedExpirationTime = null, CancellationToken cancellationToken = default) where T : class;
	}
}

