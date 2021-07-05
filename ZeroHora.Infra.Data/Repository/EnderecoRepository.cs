using System.Collections.Generic;
using Dapper;

using ZeroHora.Domain.Entities;
using ZeroHora.Domain.Interfaces;
using ZeroHora.Infra.Data.Connection;

namespace ZeroHora.Infra.Data.Repository
{
    public class EnderecoRepository : DbConnection1RepositoryBase, IEnderecoRepository
    {
        public EnderecoRepository(IDbConnectionFactory dbConnectionFactory)
            : base(dbConnectionFactory) { }

        public IEnumerable<Endereco> GetAll()
        {
            const string sql = @"SELECT *
                    FROM endereco as e
                    INNER JOIN cidade as c ON e.cidadeid = c.id
                    ORDER BY e.id ";

            var resultado = base.DbConnection.Query<Endereco, Cidade, Endereco>(sql, 
                map: (endereco, cidade) =>
                    {
                        endereco.Cidade = cidade;
                        return endereco;
                    },
                splitOn: "CidadeId,Id");

            return resultado;
        }

    }
}
