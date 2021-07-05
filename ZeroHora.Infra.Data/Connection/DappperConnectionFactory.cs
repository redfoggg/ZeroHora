using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
namespace ZeroHora.Infra.Data.Connection
{ 
    public class DapperDbConnectionFactory : IDbConnectionFactory
    {
        private readonly IDictionary<DatabaseConnectionName, string> _connectionDict;

        public DapperDbConnectionFactory(IDictionary<DatabaseConnectionName, string> connectionDict)
        {
            _connectionDict = connectionDict;
        }

        public IDbConnection CreateDbConnection(DatabaseConnectionName connectionName)
        {
            string connectionString = null;
            if (_connectionDict.TryGetValue(connectionName, out connectionString))
            {
                return new NpgsqlConnection(connectionString);
            }

            throw new ArgumentNullException();
        }
    }

}
