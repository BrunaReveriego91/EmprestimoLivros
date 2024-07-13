using AutoMapper;
using EmprestimoLivros.Application.DTOs.Autenticar;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticarController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAutenticarService _autenticarService;
        public AutenticarController(IAutenticarService autenticarService, IMapper mapper)
        {
            _mapper = mapper;
            _autenticarService = autenticarService;
        }
                
        [HttpPost()]
        [AllowAnonymous]
        public async Task<IActionResult> Autenticar(UsuarioLoginDTO usuarioLogin)
        {
            UsuarioLogin user = _mapper.Map<UsuarioLogin>(usuarioLogin);
            string token = await _autenticarService.Autenticar(user);
            return Ok(new { Token = token });
        }
    }
}
