using System;
using Application.Abstractions;
using Dapper;
using Domain.Entities;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Application.Products.Queries.GetProducts;

public record GetProductsQuery() : IRequest<List<Product>>;



