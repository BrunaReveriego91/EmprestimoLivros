using EmprestimoLivros.Domain.Enums;

namespace EmprestimoLivros.Application.Validator
{
    public class TituloValidator : BaseValidator
    {
        public async Task ValidaEnumGeneroTitulo(string generoTitulo)
        {
            await Task.Run(() =>
            {
                if (!Enum.TryParse<EnumGeneroTitulo>(generoTitulo, out var resultado))
                    throw new ArgumentException("Genero título deve ser um valor válido", nameof(generoTitulo));

            });
        }
    }
}
