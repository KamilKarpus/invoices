using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infrastructure
{
    public class SqlConnectionFactory : IDisposable, ISqlConnectionFactory
    {
        private readonly string _connectionString;
        private IDbConnection _connection;
        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IDbConnection GetConnection()
        {
            if(_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new NpgsqlConnection(_connectionString);
                return _connection;
            }
            return _connection;
        }

        public void Dispose()
        {
            if (this._connection != null && this._connection.State == ConnectionState.Open)
            {
                this._connection.Dispose();
            }
        }
    }
}
