using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroHora.Domain.Entities
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }


        public Cidade()
        {

        }
    }
}
