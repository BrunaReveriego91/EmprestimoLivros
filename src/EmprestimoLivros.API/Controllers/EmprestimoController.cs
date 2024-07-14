using EmprestimoLivros.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers
{
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoService _emprestimoService;

        public EmprestimoController(IEmprestimoService emprestimoService)
        {
            _emprestimoService = emprestimoService;
        }


        [HttpGet]
        [Authorize(Roles = "Funcionario")]
        [Route("AtualizarDevolucaoEmprestimo/{idEmprestimo}")]
        public async Task<IActionResult> AtualizarDevolucaoEmprestimo(int idEmprestimo)
        {
            try
            {
                await _emprestimoService.AtualizarDevolucaoEmprestimo(idEmprestimo);
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
