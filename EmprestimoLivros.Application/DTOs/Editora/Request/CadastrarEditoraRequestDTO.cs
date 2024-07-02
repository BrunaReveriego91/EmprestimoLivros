using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
