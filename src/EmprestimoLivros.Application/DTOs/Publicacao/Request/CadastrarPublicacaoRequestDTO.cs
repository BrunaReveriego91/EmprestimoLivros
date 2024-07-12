using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.DTOs.Publicacao.Request
{
    public class CadastrarPublicacaoRequestDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime AnoDeLancamento { get; set; }
        public string ISBN { get; set; }
        public string Descricao { get; set; }
        public string Tags { get; set; }

    }
}
