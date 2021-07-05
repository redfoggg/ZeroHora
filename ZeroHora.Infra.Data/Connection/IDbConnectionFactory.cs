using System.Data;

namespace ZeroHora.Infra.Data.Connection
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateDbConnection(DatabaseConnectionName connectionName);
    }
}
