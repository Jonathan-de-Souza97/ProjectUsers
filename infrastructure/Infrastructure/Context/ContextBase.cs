using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Infrastructure.Context
{
    public class ContextBase
    {
        private readonly string _connectionString;

        public ContextBase(IConfiguration configuration, string connectionString)
        {
            _connectionString = configuration.GetConnectionString(connectionString);
        }

        public async Task<IDbConnection> CreateOpenConnectionAsync()
        {
            var connection = new NpgsqlConnection(_connectionString);

            await connection.OpenAsync();
            return connection;
        }
    }
}