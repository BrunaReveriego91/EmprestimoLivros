using EmprestimoLivros.Application.DTOs.Publicacao.Request;
using EmprestimoLivros.Application.DTOs.Usuario.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicacaoController : ControllerBase
    {
        private readonly IPublicacaoService _publicacaoService;
        public PublicacaoController(IPublicacaoService publicacaoService) 
        {
            _publicacaoService = publicacaoService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarPublicacoes()
        {
            var publicacoes = await _publicacaoService.ListarPublicacao();
            return Ok(publicacoes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BuscarPublicacao(int id)
        {
            try
            {
                var publicacao = await _publicacaoService.BuscarPublicacao(id);
                return Ok(publicacao);
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
        public async Task<IActionResult> CadastrarPublicacao([FromBody] CadastrarPublicacaoRequestDTO publicacaoRequestDTO)
        {
            try
            {
                await _publicacaoService.CadastrarPublicacao(publicacaoRequestDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoverPublicacao(int Id)
        {
            try
            {
                await _publicacaoService.RemoverPublicacao(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
