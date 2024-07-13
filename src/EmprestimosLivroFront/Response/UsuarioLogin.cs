using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.DTOs.Autenticar
{
    public class UsuarioLogin
    {
        public string? Nome { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }
    }
}
