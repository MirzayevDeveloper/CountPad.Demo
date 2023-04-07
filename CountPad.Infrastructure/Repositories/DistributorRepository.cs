using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Domain.Models.Distributors;
using CountPad.Domain.Models.Products;
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

                string sql = @"INSERT INTO Distributors (Id, Name, company_Phone, deliverer_Phone) 
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
    }
}


