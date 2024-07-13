using Bogus;
using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Tests.Fixture
{
    public static class AutenticarFaker
    {
        public static List<UsuarioLogin> UsuariosFake { get; } = new List<UsuarioLogin>()
        {
            new UsuarioLogin { Login = "admin", Password = "admin" },
            new UsuarioLogin { Login = "usuario", Password = "usuario" },
        };
    }
}
