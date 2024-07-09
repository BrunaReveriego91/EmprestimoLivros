namespace EmprestimoLivros.Domain.Entities
{
    public class Emprestimo
    {
        public int IdEmprestimo { get; set; }
        public Usuario Usuario { get; set; }
        public Publicacao Publicacao { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public bool FoiDevolvido { get; set; } = false;
    }
}
