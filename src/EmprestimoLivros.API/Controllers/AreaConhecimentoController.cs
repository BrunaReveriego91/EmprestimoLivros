﻿using EmprestimoLivros.Application.DTOs.AreaConhecimento.Request;
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
            try
            {
                var areas = await _areaConhecimentoService.ListarTodasAreas();
                return Ok(areas);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> BuscarAreaConhecimento(int Id)
        {
            try
            {
                var areaConhecimento = await _areaConhecimentoService.BuscarAreaConhecimento(Id);
                return Ok(areaConhecimento);
            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAreaConhecimento(CadastrarAreaConhecimentoRequestDTO acDTO)
        {
            try
            {
                await _areaConhecimentoService.CadastrarAreaConheicmento(acDTO);
                return Ok();
            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoverAreaConhecimento(int Id)
        {
            try
            {
                await _areaConhecimentoService.RemoverAreaConhecimento(Id);
                return Ok();
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
