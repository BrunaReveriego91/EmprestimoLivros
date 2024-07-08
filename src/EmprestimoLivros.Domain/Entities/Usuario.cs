using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Matricula { get; set; }
        public DateTime DataNascimento { get; set; }
        public string TipoUsuario { get; set; }
    }
}
