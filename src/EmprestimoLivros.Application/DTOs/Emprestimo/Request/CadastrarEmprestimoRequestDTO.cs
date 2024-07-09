namespace EmprestimoLivros.Application.DTOs.Emprestimo.Request
{
    public class CadastrarEmprestimoRequestDTO
    {
        public int IdEmprestimo { get; set; }
        public string Matricula { get; set; }
        public int IdPublicacao { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public bool FoiDevolvido { get; set; } = false;
    }
}
