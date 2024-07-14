using EmprestimoLivros.Application.DTOs.Emprestimo.Request;
using EmprestimoLivros.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoService _emprestimoService;

        public EmprestimoController(IEmprestimoService emprestimoService)
        {
            _emprestimoService = emprestimoService;
        }


        [HttpPut]
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

        [HttpPost]
        [Authorize(Roles = "Funcionario")]
        public async Task<IActionResult> CadastrarEmprestimo(CadastrarEmprestimoRequestDTO emprestimoDTO)
        {
            try
            {
                await _emprestimoService.CadastrarEmprestimo(emprestimoDTO);
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

        [HttpGet]
        [Authorize(Roles = "Funcionario")]
        public async Task<IActionResult> ListarEmprestimos()
        {
            try
            {
                var emprestimos = await _emprestimoService.ListarEmprestimos();
                return Ok(emprestimos);
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
        [HttpDelete]
        [Authorize(Roles = "Funcionario")]
        public async Task<IActionResult> DeletarEmprestimo(int idEmprestimo)
        {
            try
            {
                await _emprestimoService.DeletarEmprestimo(idEmprestimo);
                return Ok("Emprestimo deletado com sucesso!");
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
