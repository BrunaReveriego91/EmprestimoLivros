using AutoMapper;
using EmprestimoLivros.Application.DTOs.Usuario.Request;
using EmprestimoLivros.Application.DTOs.Usuario.Response;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Interfaces;

namespace EmprestimoLivros.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<BuscarUsuarioResponseDto> BuscarUsuario(int id)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(id);

            if (usuario == null)
                throw new Exception("Usuário não está cadastrado no sistema");

            var usuarioMapper = new BuscarUsuarioResponseDto();

            await Task.Run(() =>
            {
                usuarioMapper = _mapper.Map<BuscarUsuarioResponseDto>(usuario);
            });

            return usuarioMapper;
        }

        public async Task<Usuario> BuscarUsuarioPorMatricula(string matricula)
        {
            return await _usuarioRepository.BuscarUsuarioPorMatricula(matricula);
        }

        public async Task CadastrarUsuario(CadastrarUsuarioRequestDTO usuarioDTO)
        {
            if (usuarioDTO == null)
                throw new Exception("Dados inválidos");

            var usuarioMatricula = await _usuarioRepository.BuscarUsuarioPorMatricula(usuarioDTO.Matricula);
            if (usuarioMatricula != null)
                throw new Exception("Usuário já está cadastrado no sistema");

            Usuario usuario = _mapper.Map<Usuario>(usuarioDTO);
            await _usuarioRepository.CadastrarUsuario(usuario);
        }

        public async Task<IEnumerable<BuscarUsuarioResponseDto>> ListarUsuarios()
        {
            var usuarios = await _usuarioRepository.ListarUsuarios();
            var usuariosMapper = new List<BuscarUsuarioResponseDto>();

            await Task.Run(() =>
            {
                usuariosMapper = _mapper.Map<List<BuscarUsuarioResponseDto>>(usuarios);
            });

            return usuariosMapper;
        }

        public async Task DeletarUsuario(int Id)
        {
            await _usuarioRepository.DeletarUsuario(Id);
        }
    }
}
