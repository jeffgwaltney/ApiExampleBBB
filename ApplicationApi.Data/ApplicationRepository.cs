using ApplicationApi.Models;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace ApplicationApi.Data
{
    public class ApplicationRepository : IApplicationRepository
    {
        private IConfiguration _config;
        private string _connection;

        public ApplicationRepository(IConfiguration config)
        {
            _config = config;
            _connection = _config.GetConnectionString("DataDb");
        }

        public List<Application> Applications()
        {
            List<Application> results;

            using (var connection = new SqliteConnection(_connection))
            {
                results = connection.Query<Application>($"select * from Application").ToList();
            }

            return results;
        }

        public Application Application(int id)
        {
            using (var connection = new SqliteConnection(_connection))
            {
                var result = connection.Query<Application>($"select * from Application where Id = {id}").FirstOrDefault();
                return result;
            }
        }

        public List<Application> Applications(string category, DateTime date)
        {
            List<Application> results;

            using (var connection = new SqliteConnection(_connection))
            {
                string sqlFormattedDate = date.ToString("yyyy-MM-dd HH:mm:ss.fff");
                results = connection.Query<Application>($"select * from Application where BusinessCategory = '{category}' and DateTimeUpdated = '{sqlFormattedDate}'").ToList();
            }

            return results;
        }
    }
}