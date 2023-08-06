using System;
using Application.Abstractions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public sealed class SqlConnectionFactory : ISqlConnectionFactory
{
	private readonly IConfiguration _config;

	public SqlConnectionFactory(IConfiguration config) {
		_config = config;
	}
	public SqlConnection Connect()
	{
		SqlConnection connection = new(_config.GetConnectionString("Default"));

		return connection;
	}
}

