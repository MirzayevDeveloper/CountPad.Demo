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
    }
}
