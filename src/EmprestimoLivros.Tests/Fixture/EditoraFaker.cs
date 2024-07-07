using Bogus;
using Bogus.Extensions.Brazil;
using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Tests.Fixture
{
    public static class EditoraFaker
    {
        public static List<Editora> GerarEditoraFake(int qtdeRegistros = 1)
        {
            var editoraFaker = new Faker<Editora>("pt_BR")
                .RuleFor(x => x.Id, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Nome, f => f.Random.String2(50))
                .RuleFor(x => x.CNPJ, f => f.Company.Cnpj());


            var editorasFaker = editoraFaker.Generate(qtdeRegistros);
            return editorasFaker;

        }
    }
}
