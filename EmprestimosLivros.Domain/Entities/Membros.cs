namespace EmprestimoLivros.Domain.Entities
{
    public class Membros
    {
        public int IdMembro { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public long Cep { get; set; }
        public string Endereco { get; set; }
        public int NumeroResidencia { get; set; }
        public bool SemNumero { get; set; } = false;
        public string Cidade { get; set; }
        /*TODO: Criar Enum UF*/
        public string UF { get; set; }

    }
}
