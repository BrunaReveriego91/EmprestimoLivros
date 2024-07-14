namespace EmprestimoLivros.Application.DTOs.Usuario.Response
{
    public class BuscarUsuarioResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public DateTime DataNascimento { get; set; }
        public string TipoUsuario { get; set; }
        public string Login { get; set; }
    }
}
