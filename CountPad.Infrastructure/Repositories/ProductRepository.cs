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

        public async Task<int> AddRangeAsync(IEnumerable<Product> entities)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                string sql = @"INSERT INTO Products (Id, Name, Description, Product_Type) 
                                            VALUES (@Id, @Name, @Description, @ProductType)";
                int affectedRows = connection.Execute(sql, entities);

                return affectedRows;
            }
        }

        public async Task<Product> GetByIdAsync(Guid guid)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                string sql = @"Select * from Products WHERE ID=@id";

                Product selectedProduct = await connection.QuerySingleOrDefaultAsync(sql,
                    new { Id = guid });

                return selectedProduct;
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                string sql = @"Select * from Products";

                List<Product> allProducts = connection.Query<Product>(sql).ToList();

                return allProducts;
            }
        }

        public async Task<int> UpdateAsync(Product product)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                string sql = @"Update Products
                                SET Name=@Name,
                                Product_Type=@Product_Type,
                                Description=@Description
                                WHERE ID=@id";

                var affectedRows = await connection.ExecuteAsync(sql,
                    new
                    {
                        Name = product.Name,
                        Product_Type = product.ProductType,
                        Description = product.Description
                    });

                return affectedRows;
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                string sql = @"Delete from Products WHERE ID=@id";

                int affectedRows = await connection.ExecuteAsync(sql, new { Id = id });

                return affectedRows;
            }
        }
    }
}
