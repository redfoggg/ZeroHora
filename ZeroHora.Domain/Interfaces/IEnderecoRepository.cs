using System.Collections.Generic;

using ZeroHora.Domain.Entities;

namespace ZeroHora.Domain.Interfaces
{
    public interface IEnderecoRepository
    {
        public IEnumerable<Endereco> GetAll();
    }
}
