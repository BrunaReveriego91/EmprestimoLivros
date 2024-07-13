using AutoMapper;
using EmprestimoLivros.Application.DTOs.Titulo.Request;
using EmprestimoLivros.Application.DTOs.Usuario.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Interfaces;
using EmprestimoLivros.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<Usuario> BuscarUsuario(int id)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(id);
            if (usuario == null)
                throw new Exception("Usuário não está cadastrado no sistema");

            return usuario;
        }

        public async Task CadastrarUsuario(CadastrarUsuarioRequestDTO usuarioDTO)
        {   
            if (usuarioDTO == null)
                throw new Exception("Dados inválidos");

            Usuario usuarioMatricula = await _usuarioRepository.BuscarUsuarioPorMatricula(usuarioDTO.Matricula);
            if (usuarioMatricula != null)
                throw new Exception("Usuário já está cadastrado no sistema");

            Usuario usuario = _mapper.Map<Usuario>(usuarioDTO);
            _usuarioRepository.CadastrarUsuario(usuario);
        }

        public async Task<IEnumerable<Usuario>> ListarUsuarios()
        {
            return await _usuarioRepository.ListarUsuarios();
        }
    }
}
