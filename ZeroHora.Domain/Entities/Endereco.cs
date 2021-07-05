using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroHora.Domain.Entities
{ 
    public class Endereco
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string EnderecoCasa { get; set; }
        public string NumeroCasa { get; set; }
        public string CodigoPostal { get; set; }
        public string Bairro { get; set; }
        public int CidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }

        public Endereco()
        {

        }

        public override string ToString()
        {
            return $"{Nome}, {EnderecoCasa}, {CodigoPostal}, {Bairro}, {Cidade.Municipio}, {Cidade.Estado}";
        }
    }
}
