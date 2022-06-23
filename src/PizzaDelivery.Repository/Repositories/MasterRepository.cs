using Dapper;
using Microsoft.Extensions.Configuration;
using PizzaDelivery.Repository.Interfaces;
using System.Data.SqlClient;

namespace PizzaDelivery.Repository.Repositories
{
    public class MasterRepository : IMasterRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public MasterRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = _configuration.GetSection("ConnectionString")["PizzaDelivery"];
        }

        public async Task<T> ObterUnicoResultadoAsync<T>(string query, object obj)
        {
            using (var connection = new SqlConnection(_stringConnection))
                return await connection.QueryFirstOrDefaultAsync<T>(query, obj);
        }

        public async Task<IEnumerable<T>> ObterListaAsync<T>(string query, object obj)
        {
            using (var connection = new SqlConnection(_stringConnection))
                 return await connection.QueryAsync<T>(query, obj);
        }

        public async Task<int> InserirAsync(string query, object obj)
        {
            using (var connection = new SqlConnection(_stringConnection))
                return await connection.ExecuteScalarAsync<int>(query, obj);
        }

        public async Task UpdateOrDeleteAsync(string query, object obj)
        {
            using (var connection = new SqlConnection(_stringConnection))
                await connection.ExecuteAsync(query, obj);
        }
    }
}