using Npgsql;

namespace ReportService.Infrastructure.Helpers
{
    public class DbAccessor
    {
        private readonly string _dbConnectionString;

        public DbAccessor(string connectionString)
        {
            _dbConnectionString = connectionString;
        }

        public NpgsqlConnection OpenConnection()
        {
            var connection = new NpgsqlConnection(_dbConnectionString);

            return connection;
        }

        public bool TestConnection()
        {
            using (var connection = OpenConnection())
            {
                try
                {
                    const string query = "SELECT 1";
                    var command = new NpgsqlCommand(query, connection);

                    command.ExecuteScalar();

                    return true;
                }
                catch (NpgsqlException)
                {
                    return false;
                }
            }
        }
    }
}