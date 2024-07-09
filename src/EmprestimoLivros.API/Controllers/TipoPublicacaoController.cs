using EmprestimoLivros.Application.DTOs.TipoPublicacao.Request;
using EmprestimoLivros.Application.DTOs.Usuario.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TipoPublicacaoController : ControllerBase
    {
        private readonly ITipoPublicacaoService _tipoPublicacaoService;
        public TipoPublicacaoController(ITipoPublicacaoService tipoPublicacaoService)
        {
            _tipoPublicacaoService = tipoPublicacaoService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTipoPublicacao()
        {
            var tipoPublicacoes = await _tipoPublicacaoService.ListarTipoPublicacao();
            return Ok(tipoPublicacoes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BuscarTipoPublicacao(string pub)
        {
            try
            {
                var tipo = await _tipoPublicacaoService.BuscarTipoPublicacao(pub);
                return Ok(tipo);
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
        public async Task<IActionResult> CadastrarTipoPublicacao([FromBody] CadastrarTipoPublicacaoRequestDTO tipoPublicacaoDTO)
        {
            try
            {
                await _tipoPublicacaoService.CadastrarTipoPublicacao(tipoPublicacaoDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoverTipoPublicacao(int Id)
        {
            try
            {
                await _tipoPublicacaoService.RemoverTipoPublicacao(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
