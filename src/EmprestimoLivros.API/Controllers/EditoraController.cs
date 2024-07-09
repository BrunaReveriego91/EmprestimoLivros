using EmprestimoLivros.Application.DTOs.Editora.Request;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Services;
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
        public async Task<IActionResult> ListarEditoras()
        {

            var editoras = await _editoraService.ListarEditoras();
            return Ok(editoras);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BuscarEditora(int id)
        {
            try
            {
                var editora = await _editoraService.BuscarEditora(id);
                return Ok(editora);
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
        public async Task<IActionResult> CadastrarEditora([FromBody] CadastrarEditoraRequestDTO editoraDTO)
        {
            try
            {
                await _editoraService.CadastrarEditora(editoraDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoverEditora(int Id)
        {
            try
            {
                await _editoraService.RemoverEditora(Id);
                return Ok();
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
    }
}
