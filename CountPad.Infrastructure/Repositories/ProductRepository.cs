// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Domain.Models.Products;
using Dapper;
using Npgsql;

namespace CountPad.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {

        public async Task<int> AddAsync(Product product)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {

                string sql = @"INSERT INTO Products (Id, Name, ProductType, Description) 
                                            VALUES (@Id, @Name, @ProductType, @Description)";

                int affectedRows = await connection.ExecuteAsync(sql, new
                {
                    product.Id,
                    product.Name,
                    ProductType = product.ProductType,
                    product.Description
                });

                return affectedRows;
            }
        }
    }
}

