namespace EmprestimoLivros.Application.DTOs.Usuario.Request
{
    public class CadastrarUsuarioRequestDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public DateTime DataNascimento { get; set; }
        public string TipoUsuario { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
