using EmprestimoLivros.Domain.Enums;

namespace EmprestimoLivros.Domain.Entities
{
    public class Titulos
    {
        public string NomeTitulo { get; set; }
        public int AnoLancamento { get; set; }
        public string ISBN { get; set; }
        public string? Descricao { get; set; }

        public EnumGeneroTitulo GeneroTitulo { get; set; }

    }
}
