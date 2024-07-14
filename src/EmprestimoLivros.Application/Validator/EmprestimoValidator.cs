using EmprestimoLivros.Application.DTOs.Emprestimo.Request;
using System.Text;

namespace EmprestimoLivros.Application.Validator
{
    public class EmprestimoValidator : BaseValidator
    {
        /*Requisito: Cadastrar ou editar reserva */
        public async Task ValidaCamposObrigatorios(CadastrarEmprestimoRequestDTO emprestimoDTO)
        {
            var validaCampos = new List<string>();

            await Task.Run(() =>
            {
                if (emprestimoDTO.Id <= 0)
                {
                    validaCampos.Add("Id empréstimo");
                }

                if (string.IsNullOrEmpty(emprestimoDTO.Matricula))
                {
                    validaCampos.Add("Matrícula ");
                }

                if (emprestimoDTO.IdPublicacao <= 0)
                {
                    validaCampos.Add("Id publicação");
                }

            });

            if (validaCampos.Any())
            {
                var stringValidacao = new StringBuilder();

                stringValidacao.Append("Os seguintes campos não foram preenchidos ou estão inválidos : ");

                foreach (var campo in validaCampos)
                {
                    stringValidacao.Append(campo);
                    stringValidacao.Append(',');
                }

                throw new ArgumentException(stringValidacao.ToString().Remove(stringValidacao.Length - 1);
            }


        }
    }
}
