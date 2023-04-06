// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
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

                string sql = @"INSERT INTO Products (Id, Name, Description, Product_Type) 
                                            VALUES (@Id, @Name, @Description, @ProductType)";

                int affectedRows = connection.Execute(sql,
                    new Dictionary<string, object>
                        {
                            { "Id", product.Id },
                            { "Name", product.Name },
                            { "Description", product.Description },
                            { "ProductType", product.ProductType.ToString() }
                        });

                return affectedRows;
            }
        }

        public async Task<List<Product>> SelectAllAsync()
        {
            using (NpgsqlConnection connection = CreateConnection())
            {

                string selectAllProductsQuery = "select * from Products";

                IEnumerable<Product> products = (IEnumerable<Product>)connection
                    .Query(selectAllProductsQuery);

                return products.ToList();
            }
        }
    }
}
