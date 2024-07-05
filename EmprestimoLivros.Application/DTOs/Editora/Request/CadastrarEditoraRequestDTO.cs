using MongoDB.Bson.Serialization.Attributes;

namespace EmprestimoLivros.Application.DTOs.Editora.Request
{
    public class CadastrarEditoraRequestDTO
    {
        [BsonId]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
    }
}
