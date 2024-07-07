using MongoDB.Bson.Serialization.Attributes;

namespace EmprestimoLivros.Domain.Entities
{
    public class Titulo
    {
        [BsonId]
        public int Id { get; set; }
        public string NomeTitulo { get; set; }
        public int AnoLancamento { get; set; }
        public string ISBN { get; set; }
        public string? Descricao { get; set; }
        public Editora Editora { get; set; }
        public string GeneroTitulo { get; set; }

    }
}
