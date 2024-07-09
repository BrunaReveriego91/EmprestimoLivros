using AutoMapper;
using EmprestimoLivros.Application.DTOs.Autenticar;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Interfaces;
using EmprestimoLivros.Infra.Data.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Services
{
    public class AutenticarService : IAutenticarService
    {
        private readonly Mapper _mapper;
        private readonly IAutenticarRepository _autenticarRepository;
        private readonly IJwtToken _jwtToken;
        public AutenticarService(IAutenticarRepository autenticarRepository, Mapper mapper, IJwtToken jwtToken) 
        {
            _mapper = mapper;   
            _autenticarRepository = autenticarRepository;
            _jwtToken = jwtToken;
        }

        public async Task<string> Autenticar(UsuarioLogin usuarioLogin)
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
