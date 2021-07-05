using System.Collections.Generic;
using System.Data;
using Dapper;

using ZeroHora.Domain.Entities;
using ZeroHora.Domain.Interfaces;


namespace ZeroHora.Infra.Data.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly IDbConnection _dbConnection;
        public EnderecoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Endereco> GetAll()
        {
            const string sql = @"SELECT *
                    FROM endereco as e
                    INNER JOIN cidade as c ON e.cidadeid = c.id
                    ORDER BY e.id ";

            var resultado = _dbConnection.Query<Endereco, Cidade, Endereco>(sql,
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
