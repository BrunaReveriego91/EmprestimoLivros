namespace EmprestimoLivros.Application.DTOs.Publicacao.Request
{
    public class CadastrarPublicacaoRequestDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdTipoPublicacao { get; set; }
        public string Autor { get; set; }
        public int IdEditora { get; set; }
        public int IdAreaConhecimento { get; set; }
        public DateTime AnoDeLancamento { get; set; }
        public string ISBN { get; set; }
        public string? Descricao { get; set; }
        public string? Tags { get; set; }
    }
}
