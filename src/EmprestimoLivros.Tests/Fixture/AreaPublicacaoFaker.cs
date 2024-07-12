using Bogus;
using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Tests.Fixture
{
    public static class AreaPublicacaoFaker
    {
        public static List<AreaConhecimento> GerarEditoraFake(int qtdeRegistros = 1)
        {
            var acFaker = new Faker<AreaConhecimento>("pt_BR")
                .RuleFor(x => x.Id, f => f.Random.Int(1, 100))
                .RuleFor(x => x.NomeArea, f => f.Random.String2(50));


            var areasConhecimentoFaker = acFaker.Generate(qtdeRegistros);
            return areasConhecimentoFaker;

        }
    }
}
