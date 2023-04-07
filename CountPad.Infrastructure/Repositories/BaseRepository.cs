// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.IO;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace CountPad.Infrastructure.Repositories
{
    public class BaseRepository
    {
        private readonly IConfiguration configuration;

        public BaseRepository()
        {
            this.configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() +
                    "../../../../../CountPad.Infrastructure")
                        .AddJsonFile("appsettings.json", optional: true).Build();

            CheckDataBaseExists(configuration.GetConnectionString("Postgres"));
        }

        protected NpgsqlConnection CreateConnection() =>
            new NpgsqlConnection(this.configuration
                .GetConnectionString("CountPadConnection"));

        private async void CheckDataBaseExists(string stringConnection)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    connection.Open();
                }
            }
            catch (Exception)
            {
                using (var connection = new NpgsqlConnection(stringConnection))
                {
                    connection.Open();
                    string query = $"create database countpaddb";

                    connection.Execute(query);
                    CreateTables();
                }
            }

        }

        private void CreateTables()
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                connection.Open();

                string query = $@"{File.ReadAllText("../../../../CountPad.Infrastructure/query.txt")}";
                connection.Execute(query);
            }
        }
    }
}

