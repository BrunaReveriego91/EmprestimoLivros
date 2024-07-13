using Bogus;
using Bogus.Extensions.Brazil;
using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Tests.Fixture
{
    public static class PublicacaoFaker
    {
        public static List<Publicacao> GerarPublicacaoFake(int qtdeRegistros = 1)
        {
            var editoraFaker = new Faker<Editora>()
               .RuleFor(e => e.Id, f => f.Random.Int(1, 100))
               .RuleFor(e => e.Nome, f => f.Company.CompanyName())
               .RuleFor(e => e.CNPJ, f => f.Company.Cnpj());

            var tipoPublicacaoFaker = new Faker<TipoPublicacao>()
                .RuleFor(tp => tp.Id, f => f.Random.Int(1, 100))
                .RuleFor(tp => tp.Nome, f => f.Random.Word());


            var publicacaoFaker = new Faker<Publicacao>("pt_BR")
                .RuleFor(x => x.Id, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Nome, f => f.Random.String2(50))
                .RuleFor(x => x.TipoPublicacao, () => tipoPublicacaoFaker.Generate())
                .RuleFor(x => x.Autor, f => f.Random.String2(20))
                .RuleFor(x => x.Editora, () => editoraFaker.Generate());


            var publicacoesFaker = publicacaoFaker.Generate(qtdeRegistros);
            return publicacoesFaker;

        }
    }
}
