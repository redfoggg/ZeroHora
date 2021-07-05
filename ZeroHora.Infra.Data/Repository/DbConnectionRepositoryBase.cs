using System.Data;

using ZeroHora.Infra.Data.Connection;

namespace ZeroHora.Infra.Data.Repository
{
    public abstract class DbConnection1RepositoryBase
    {
        public IDbConnection DbConnection { get; private set; }

        public DbConnection1RepositoryBase(IDbConnectionFactory dbConnectionFactory)
        {
            this.DbConnection = dbConnectionFactory.CreateDbConnection(DatabaseConnectionName.Connection1);
        }
    }

}
