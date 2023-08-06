using System;
using Application.Abstractions;
using Dapper;
using Domain.Entities;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Application.Products.Commands.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand>
{
	private readonly ISqlConnectionFactory _connectionFactory;

	public CreateProductHandler(ISqlConnectionFactory connectionFactory) {
		_connectionFactory = connectionFactory;
	}
	public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
	{
		using SqlConnection connection = _connectionFactory.Connect();

		try {

			await connection.ExecuteAsync("insert into Products (Title, Price, Availability) output Inserted.* values (@title, @price, @availability)",
					new {
						title = request.title,
						price = request.price,
						availability = request.availability
					}
				);
		}catch(SqlException ex) {
			throw;
		}
	}

	
}

