// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Domain.Models.Orders;
using Dapper;
using Npgsql;

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
    }
}
