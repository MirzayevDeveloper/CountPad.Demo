// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Domain.Models.Distributors;
using CountPad.Domain.Models.Packages;
using CountPad.Domain.Models.Products;
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

        public async Task<int> AddRangeAsync(IEnumerable<Package> packages)
        {
            var tasks = packages.Select(p => AddAsync(p));
            int[] results = await Task.WhenAll(tasks);
            return results.Sum();
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                string query = @"DELETE FROM packages WHERE id = @Id";
                int affectedRows = await connection.ExecuteAsync(query, new { Id = id });

                return affectedRows;
            }
        }

        public async Task<List<Package>> GetAllAsync()
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                string query = @"SELECT * FROM packages";
                List<Package> packages = await connection.QueryAsync<Package>(query);

                return packages;
            }
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
