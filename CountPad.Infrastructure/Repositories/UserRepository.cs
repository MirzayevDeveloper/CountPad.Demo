// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Domain.Models.Packages;
using CountPad.Domain.Models.Users;
using Dapper;
using Npgsql;
using static Dapper.SqlMapper;

namespace CountPad.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public async Task<int> AddAsync(User user)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                string sql = @"INSERT INTO users (id, name, phone, user_status, password) 
                                            VALUES (@Id, @Name, @Phone, @Status,@Password)";

                int affectedRows = await connection.ExecuteAsync(sql,
                   new Dictionary<string, object>
                   {
                       { "Id", user.Id },
                       { "Name", user.Name },
                       { "Phone", user.Phone },
                       {"Password",user.Password},
                       { "Status", user.Status.ToString()}
                   });

                return affectedRows;
            }
        }

        public async Task<int> AddRangeAsync(IEnumerable<User> entities)
        {
            await using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                string query= @"INSERT INTO users (id, name, phone, user_status, password) 
                                            VALUES (@Id, @Name, @Phone, @Status,@Password)";

                int rowAffected = default;

                foreach (User entity in entities)
                {
                    rowAffected = await connection.ExecuteAsync(query, new
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Phone = entity.Phone,
                        Status = entity.Status,
                        Password=entity.Password
                    });
                }
                return rowAffected;
            }
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                string query = @"SELECT * FROM users WHERE id=@Id";

                return connection.QuerySingleOrDefault<User>(query, new { Id = id });
            }
        }

        public async Task<List<User>> GetAllAsync()
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                string query = @"SELECT * FROM users";

                return connection.Query<User>(query).ToList();
            }
        }

        public async Task<int> UpdateAsync(User entity)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                string query = "UPDATE users SET name=@Name, phone=@Phone, user_status=@Status, password=@Password WHERE id = @Id";
                
                return await connection.ExecuteAsync(query, new
                {
                    Id = entity.Id,
                    Name=entity.Name,
                    Phone = entity.Phone,
                    Status = entity.Status,
                    Password=entity.Password
                });
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                string query = @"DELETE FROM users WHERE id = @Id";
                int affectedRows = await connection.ExecuteAsync(query, new { Id = id });

                return affectedRows;
            }
        }

    }
}
