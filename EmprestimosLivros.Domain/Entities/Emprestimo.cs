namespace EmprestimoLivros.Domain.Entities
{
    public class Emprestimo
    {
        public int IdEmprestimo { get; set; }
        public int IdMembro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public bool EmprestimoFinalizado { get; set; } = false;
    }
}
