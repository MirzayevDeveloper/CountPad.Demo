// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
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
            await using(NpgsqlConnection connection = CreateConnection())
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

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
