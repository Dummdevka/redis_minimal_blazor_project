using System;
using Application.Abstractions;
using Dapper;
using Domain.Entities;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Application.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Product>>
{
	private readonly ISqlConnectionFactory _connectionFactory;

	public GetProductsQueryHandler(ISqlConnectionFactory connectionFactory) {
		_connectionFactory = connectionFactory;
	}

	public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken) {
		using SqlConnection connection = _connectionFactory.Connect();

		List<Product> products = (List<Product>)await connection.QueryAsync<Product>("select Id, Title, Price, Availability from Products");

		return products;
	}

}

