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

                string sql = @"INSERT INTO Distributors (Id, Name, Description, Product_Type) 
                                            VALUES (@Id, @Name, @Description, @ProductType)";

                int affectedRows = connection.Execute(sql,
                    new Dictionary<string, object>
                    {
                        { "Id", distributor.Id },
                        { "Name", distributor.Name },
                        { "Description", distributor.CompanyPhone },
                        { "ProductType", distributor.DelivererPhone}
                    });

                return affectedRows;
            }
        }
    }
}


