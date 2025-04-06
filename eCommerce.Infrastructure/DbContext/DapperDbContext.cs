using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure.DbContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;
        public DapperDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            string? connectionString = _configuration.GetConnectionString("PostgresConnection");

            //Create a new npgsql connection with the retrived connection string 
            _connection =  new NpgsqlConnection(connectionString);
        }

        public IDbConnection DbConnection => _connection;
    }
}
