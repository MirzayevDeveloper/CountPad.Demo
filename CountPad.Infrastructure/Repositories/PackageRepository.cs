// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
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
      /*  id uuid NOT NULL,
    product_id uuid NOT NULL References products(id),
    count DOUBLE PRECISION NOT NULL,
    distributor_id uuid NOT NULL References distributors(id),
    incoming_price DECIMAL(10, 2) NOT NULL,
    sale_price DECIMAL(10, 2) NOT NULL,
    incoming_date date,
    PRIMARY KEY(id)*/


    }
}
