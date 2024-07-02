using MongoDB.Bson.Serialization.Attributes;

namespace EmprestimoLivros.Domain.Entities
{
    public class Editora
    {
        [BsonId]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }

    }
}
