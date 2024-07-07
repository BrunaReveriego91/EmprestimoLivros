using EmprestimoLivros.Domain.Enums;

namespace EmprestimoLivros.Application.DTOs.Titulo.Request
{
    public class CadastrarTituloRequestDTO
    {
        public int Id { get; set; }
        public string NomeTitulo { get; set; }
        public int AnoLancamento { get; set; }
        public string ISBN { get; set; }
        public string? Descricao { get; set; }
        public int IdEditora { get; set; }
        public string GeneroTitulo { get; set; }
    }
}
