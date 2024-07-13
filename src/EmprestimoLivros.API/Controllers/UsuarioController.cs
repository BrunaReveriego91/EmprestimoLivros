using EmprestimoLivros.Application.DTOs.Titulo.Request;
using EmprestimoLivros.Application.DTOs.Usuario.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService) 
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            var usuarios = await _usuarioService.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BuscarUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioService.BuscarUsuario(id);
                return Ok(usuario);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario([FromBody] CadastrarUsuarioRequestDTO usuarioDTO)
        {
            try
            {
                await _usuarioService.CadastrarUsuario(usuarioDTO);
                return Ok("Usuário cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
