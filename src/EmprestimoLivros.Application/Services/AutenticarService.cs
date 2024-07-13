using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Interfaces;

namespace EmprestimoLivros.Application.Services
{
    public class AutenticarService : IAutenticarService
    {        
        private readonly IAutenticarRepository _autenticarRepository;
        private readonly IJwtToken _jwtToken;
        public AutenticarService(IAutenticarRepository autenticarRepository, IJwtToken jwtToken) 
        {
            _autenticarRepository = autenticarRepository;
            _jwtToken = jwtToken;
        }

        public async Task<string> Autenticar(Usuario usuarioLogin)
        {
            if (usuarioLogin.Login == null)
                throw new Exception("Login não pode ser nulo");
            if (usuarioLogin.Password == null)
                throw new Exception("Senha não pode ser nulo");

            Usuario user = await _autenticarRepository.Autenticar(usuarioLogin);
            if(user == null)
                throw new Exception("Login ou senha não existem");
            return _jwtToken.GenerateToken(user); ;
        }
    }
}
