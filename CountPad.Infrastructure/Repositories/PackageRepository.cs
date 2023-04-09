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
using CountPad.Domain.Models.Orders;
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
            await using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                string query = @"INSERT INTO packages 
                                (id, product_id, count, distributor_id, incoming_price, 
                                sale_price, incoming_date)
                                 VALUES (@Id, @Product, @Count, @Distributor,
                                @IncomingPrice, @SalePrice, @IncomingDate)";

                int changedNumber = default;

                foreach (Package entity in packages)
                {
                    changedNumber += await connection.ExecuteAsync(query, new
                    {
                        Id = entity.Id,
                        Product = entity.Product,
                        Count=entity.Count,
                        Distributor=entity.Distributor,
                        IncomingPrice=entity.IncomingPrice,
                        SalePrice=entity.SalePrice,
                        IncomingDate=entity.IncomingDate
                    });
                }
                return changedNumber;
            }
        }

        public async Task<Package> GetByIdAsync(Guid id)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                string query = @"SELECT * FROM packages WHERE id=@Id";

                return connection.QuerySingleOrDefault<Package>(query, new { Id=id});
            }
        }

        public async Task<List<Package>> GetAllAsync()
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                string query = @"SELECT * FROM packages";
      
                return connection.Query<Package>(query).ToList();
            }
        }
        
        public async Task<int> UpdateAsync(Package entity)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                var query = "UPDATE packages SET product_id = @Product, count =@Count, distributor_id =@Distributor," +
                    "incoming_price = @IncomingPrice, sale_price=@SalePrice, incoming_date=@IncomingDate  WHERE id = @Id";

                return await connection.ExecuteAsync(query, new
                {
                    Id = entity.Id,
                    Product = entity.Product.Id,
                    Count = entity.Product.Id,
                    Distributor=entity.Distributor.Id,
                    IncomingPrice=entity.IncomingPrice,
                    SalePrice=entity.SalePrice,
                    IncomingDate=entity.IncomingDate
                });
            }
        }
        
        public async Task<int> DeleteAsync(Guid id)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                string query = @"DELETE FROM packages WHERE id = @Id";
                int affectedRows = await connection.ExecuteAsync(query, new { Id = id });

                return affectedRows;
            }
        }
    }
}
