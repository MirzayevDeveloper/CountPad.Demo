// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Domain.Models.Packages;
using Dapper;
using Npgsql;
using static Dapper.SqlMapper;

namespace CountPad.Infrastructure.Repositories
{
    public class PackageRepository : BaseRepository, IPackageRepository
    {
        public async Task<int> AddAsync(Package entity)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                string query = @"INSERT INTO packages 
                                (id, product_id, count, distributor_id, incoming_price, 
                                sale_price, incoming_date)
                                 VALUES (@Id, @Product, @Count, @Distributor,
                                @IncomingPrice, @SalePrice, @IncomingDate)";

                int affectedRows = connection.Execute(query,
                   new Dictionary<string, object>
                       {
                            { "Id", entity.Id },
                            { "Product", entity.Product.Id },
                            { "Count", entity.Count },
                            { "Distributor", entity.Distributor.Id },
                            { "IncomingPrice", entity.IncomingPrice },
                            { "SalePrice", entity.SalePrice },
                            { "IncomingDate", entity.IncomingDate },
                       });

                return affectedRows;
            }
        }

        public async Task<int> AddRangeAsync(IEnumerable<Package> entities)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();
                int affectedR = 0;
                foreach (Package package in entities)
                {
                    int affectedR = await AddAsync(package);
                }

                return affectedR;
            }
            
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Package>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Package> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> UpdateAsync(Package entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
