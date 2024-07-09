namespace EmprestimoLivros.Domain.Entities
{
    public class Publicacao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoPublicacao TipoPublicacao { get; set; }
        public string Autor {  get; set; }
        public Editora Editora { get; set; }
        public AreaConhecimento AreaConhecimento { get; set; }
        public DateTime AnoDeLancamento { get; set; }
        public string ISBN { get; set; }
        public string? Descricao {  get; set; }
        public string? Tags { get; set; }

    }
}
