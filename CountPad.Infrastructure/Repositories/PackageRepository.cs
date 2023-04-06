using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Domain.Models.Distributors;
using CountPad.Domain.Models.Packages;
using CountPad.Domain.Models.Products;
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
                                @IncomingPrice, @SalePrice, @IncomingPrice)";

                return await connection.ExecuteAsync(query, new
                {
                    Id = entity.Id,
                    Product = entity.Product.Id,
                    Count = entity.Count,
                    Distributor = entity.Distributor.Id,
                    IncomingPrice = entity.IncomingPrice,
                    SalePrice = entity.SalePrice,
                    IncomingDate = entity.IncomingDate
                });
            }
        }



    }
}
