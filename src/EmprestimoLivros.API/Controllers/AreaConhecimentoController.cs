using EmprestimoLivros.Application.DTOs.AreaConhecimento.Request;
using EmprestimoLivros.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AreaConhecimentoController : ControllerBase
    {
        private readonly IAreaConhecimentoService _areaConhecimentoService;
        public AreaConhecimentoController(IAreaConhecimentoService areaConhecimentoService) 
        { 
            _areaConhecimentoService = areaConhecimentoService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarAreasConhecimento() 
        {
            var areas = await _areaConhecimentoService.ListarTodasAreas();
            return Ok(areas);
        }

        [HttpPost]
        [Route("{Id}")]
        public async Task<IActionResult> BuscarAreaConhecimento(int Id)
        {
            var areaConhecimento = await _areaConhecimentoService.BuscarAreaConhecimento(Id);
            return Ok(areaConhecimento);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAreaConhecimento(CadastrarAreaConhecimentoRequestDTO acDTO)
        {
            await _areaConhecimentoService.CadastrarAreaConheicmento(acDTO);
            return Ok();
        }
    }
}
