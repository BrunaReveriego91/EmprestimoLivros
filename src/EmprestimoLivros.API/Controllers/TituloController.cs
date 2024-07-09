using EmprestimoLivros.Application.DTOs.Titulo.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TituloController : ControllerBase
    {
        private readonly ITituloService _tituloService;

        public TituloController(ITituloService tituloService)
        {
            _tituloService = tituloService;
        }


        [HttpGet]
        public async Task<IActionResult> ListarTitulos()
        {
            var titulos = await _tituloService.ListarTitulos();
            return Ok(titulos);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BuscarTitulos(int id)
        {
            try
            {
                var titulo = await _tituloService.BuscarTitulo(id);
                return Ok(titulo);
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
        public async Task<IActionResult> CadastrarTitulos([FromBody] CadastrarTituloRequestDTO tituloDTO)
        {
            try
            {
                await _tituloService.CadastrarTitulo(tituloDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoverTitulo(int Id)
        {
            try
            {
                await _tituloService.RemoverTitulo(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
