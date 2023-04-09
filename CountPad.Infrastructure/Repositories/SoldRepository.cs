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
using CountPad.Domain.Models.Solds;
using Dapper;
using Npgsql;

namespace CountPad.Infrastructure.Repositories
{
    public class SoldRepository : BaseRepository, ISoldRepository
    {
        public async Task<int> AddAsync(Sold entity)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                string query = $"INSERT INTO solds " +
                            $"(id, sold_date, user_id)" +
                            "VALUES(@Id, @SoldDate, @UserId)";

                int rowsAffected = await connection.ExecuteAsync(query, new
                {
                    Id = entity.Id,
                    SoldDate = entity.SoldDate,
                    UserId = entity.User.Id,
                });

                return rowsAffected;
            }
        }

        public async Task<int> AddRangeAsync(IEnumerable<Sold> entities)
        {
            await using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                string query = $"INSERT INTO solds " +
                            $"(id, sold_date, user_id)" +
                            "VALUES(@Id, @SoldDate, @UserId)";

                int rowsAffected = default;

                foreach (Sold entity in entities)
                {
                   rowsAffected = await connection.ExecuteAsync(query, new
                    {
                        Id = entity.Id,
                        SoldDate = entity.SoldDate,
                        UserId = entity.User.Id,
                    });
                }
                return rowsAffected;
            }
        }


        public async Task<Sold> GetByIdAsync(Guid id)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                var query = "SELECT * FROM solds WHERE id = @Id";

                return await connection.QuerySingleOrDefaultAsync<Sold>(
                    query, new { Id = id });
            }
        }
        public async Task<List<Sold>> GetAllAsync()
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                var query = "SELECT * FROM solds";

                return connection.Query<Sold>(query).ToList();
            }
        }

        public async Task<int> UpdateAsync(Sold entity)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();
                
                string query = "UPDATE classes SET sold_date = @SoldDate" +
                        "user_id = @UserId WHERE id = @Id";

                return await connection.ExecuteAsync(query, new
                {
                    Id = entity.Id,
                    SoldDate = entity.SoldDate,
                    UserId = entity.User.Id
                });
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                string query = "DELETE FROM solds WHERE id = @Id";

                int rowsAffected = await connection.ExecuteAsync(query, new { Id = id });

                return rowsAffected;
            }
        }
    }
}
