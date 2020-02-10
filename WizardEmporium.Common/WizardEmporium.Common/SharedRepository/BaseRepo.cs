using System;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace WizardEmporium.Common.SharedRepository
{
    public abstract class BaseRepo
    {
        private readonly string connectionString;

        public BaseRepo(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new NotSupportedException("You must specify a connection string.");
            this.connectionString = connectionString;
        }

        protected async Task<SQLiteConnection> getConnectionAsync()
        {
            var connection = new SQLiteConnection(connectionString);
            await connection.OpenAsync();
            return connection;
        }

        protected async Task<T> GetConnectionAsync<T>(Func<SQLiteConnection, Task<T>> action)
        {
            using var conn = await getConnectionAsync();
            return await action(conn);
        }
    }
}
