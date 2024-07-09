using EmprestimoLivros.Application.DTOs.AreaConhecimento.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Validator
{
    public class AreaConhecimentoValidator : BaseValidator
    {
        public async Task validaCamposAreaConhecimento(CadastrarAreaConhecimentoRequestDTO requestDTO)
        {
            await Task.Run(() =>
            {
                if(requestDTO == null) 
                    throw new ArgumentNullException("Dados para cadastro de area de conhecimento são inválidos " + nameof(requestDTO));

                if (string.IsNullOrEmpty(requestDTO.NomeArea))
                    throw new ArgumentException("O nome da area de conhecimento é obrigatório");
            });
        }
    }
}
