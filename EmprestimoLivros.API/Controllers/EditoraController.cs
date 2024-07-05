using EmprestimoLivros.Application.DTOs.Editora.Request;
using EmprestimoLivros.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EditoraController : ControllerBase
    {
        private readonly IEditoraService _editoraService;

        public EditoraController(IEditoraService editoraService)
        {
            _editoraService = editoraService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BuscarEditora(int id)
        {
            var editora = await _editoraService.BuscarEditora(id);
            return Ok(editora);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarEditora([FromBody] CadastrarEditoraRequestDTO editoraDTO)
        {
            await _editoraService.CadastrarEditora(editoraDTO);
            return Ok();
        }
    }
}
