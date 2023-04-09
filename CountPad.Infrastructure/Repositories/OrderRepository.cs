// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Domain.Models.Orders;
using Dapper;
using Npgsql;
using static Dapper.SqlMapper;

namespace CountPad.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public async Task<int> AddAsync(Order entity)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();
                string query = $"INSERT INTO orders " +
                            $"(id, package_id, sold_id, count, sold_price)" +
                            "VALUES(@Id, @Package, @Sold, @Count, @SoldPrice)";

                int changedNumber = await connection.ExecuteAsync(query, new
                {
                    Id = entity.Id,
                    Package = entity.Package.Id,
                    Sold = entity.Sold.Id,
                    Count = entity.Package.Count,
                    SoldPrice = entity.Package.SalePrice
                });

                return changedNumber;
            }
        }

        public async Task<int> AddRangeAsync(IEnumerable<Order> entities)
        {
            await using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                string query = $"INSERT INTO orders " +
                            $"(id, package_id, sold_id, count, sold_price)" +
                            "VALUES(@Id, @Package, @Sold, @Count, @SoldPrice)";

                int changedNumber = default;

                foreach (Order entity in entities)
                {
                    changedNumber += await connection.ExecuteAsync(query, new
                    {
                        Id = entity.Id,
                        Package = entity.Package.Id,
                        Sold = entity.Sold.Id,
                        Count = entity.Package.Count,
                        SoldPrice = entity.Package.SalePrice
                    });
                }
                return changedNumber;
            }
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                var query = "SELECT * FROM orders WHERE id = @Id";

                return await connection.QuerySingleOrDefaultAsync<Order>(
                    query, new { Id = id });
            }
        }

        public async Task<List<Order>> GetAllAsync()
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                var query = "SELECT * FROM orders";

                return connection.Query<Order>(query).ToList();
            }
        }

        public async Task<int> UpdateAsync(Order entity)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                var query = "UPDATE classes SET package_id = @PackageId" +
                        "sold_id = @SoldId WHERE id = @Id";

                return await connection.ExecuteAsync(query, new
                {
                    Id = entity.Id,
                    PackageId = entity.Package.Id,
                    SoldId = entity.Sold.Id
                });
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                string query = "DELETE FROM orders WHERE id = @Id";

                int rowsAffected = await connection.ExecuteAsync(query, new { Id = id });

                return rowsAffected;
            }
        }
    }
}
