namespace EmprestimoLivros.Domain.Entities
{
    public class Emprestimos
    {
        public int IdEmprestimo { get; set; }
        public int IdMembro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public bool EmprestimoFinalizado { get; set; } = false;
    }
}
