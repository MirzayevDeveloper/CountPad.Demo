// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Domain.Models.Distributors;
using Dapper;
using Npgsql;

namespace CountPad.Infrastructure.Repositories
{
    public class DistributorRepository : BaseRepository, IDistributorRepository
    {

        public async Task<int> AddAsync(Distributor distributor)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {

                string sql = @"INSERT INTO Distributors
                                    (id, name, company_Phone, deliverer_Phone) 
                                    VALUES (@Id, @Name, @CompanyPhone, @DelivererPhone)";

                int affectedRows = connection.Execute(sql,
                    new Dictionary<string, object>
                    {
                        { "Id", distributor.Id },
                        { "Name", distributor.Name },
                        { "CompanyPhone", distributor.CompanyPhone },
                        { "DelivererPhone", distributor.DelivererPhone}
                    });

                return affectedRows;
            }
        }

        public async Task<int> AddRangeAsync(IEnumerable<Distributor> entities)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                string sql = @"INSERT INTO Distributors
                                    (id, name, company_Phone, deliverer_Phone) 
                                    VALUES (@Id, @Name, @CompanyPhone, @DelivererPhone)";

                int affectedRows = connection.Execute(sql, entities);

                return affectedRows;
            }
        }

        public async Task<Distributor> GetByIdAsync(Guid id)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                string sql = @"Select * from Distributors WHERE ID=@id";

                Distributor selectedDistributor = await connection.QuerySingleOrDefaultAsync(sql,
                    new { Id = id });

                return selectedDistributor;
            }
        }

        public async Task<List<Distributor>> GetAllAsync()
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                string sql = @"Select * from Distributors";

                List<Distributor> allDistributors =
                    connection.Query<Distributor>(sql).ToList();

                return allDistributors;
            }
        }

        public async Task<int> UpdateAsync(Distributor distributor)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                string sql = @"Update Distributors
                                SET name=@Name,
                                company_Phone=@Company_Phone,
                                deliverer_Phone=@Delivery_Phone
                                WHERE id=@id";

                var affectedRows = await connection.ExecuteAsync(sql,
                            new
                            {
                                Name = distributor.Name,
                                Company_Phone = distributor.CompanyPhone,
                                Delivery_Phone = distributor.DelivererPhone
                            });

                return affectedRows;
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                string sql = @"Delete from Distributors WHERE ID=@id";

                int affectedRows = await connection.ExecuteAsync(sql, new { Id = id });

                return affectedRows;
            }
        }

    }
}


