using AutoMapper;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Mappings.AutoMapperConfig;
using EmprestimoLivros.Application.Services;
using EmprestimoLivros.Application.Validator;
using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Infra.Data.Interfaces;
using EmprestimoLivros.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EmprestimoLivros.Infra.IoC
{
    public static class IoCConfiguration
    {
        public static void ConfigureRepository(IServiceCollection services)
        {
            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IEditoraRepository, EditoraRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITipoPublicacaoRepository, TipoPublicacaoRepository>();
            services.AddScoped<IPublicacaoRepository, PublicacaoRepository>();
            services.AddScoped<IAreaConhecimentoRepository, AreaConhecimentoRepository>();
            services.AddScoped<IAutenticarRepository, AutenticarRepository>();
        }

        public static void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<EditoraValidator>();
            services.AddScoped<TituloValidator>();
            services.AddScoped<UsuarioValidator>();
            services.AddScoped<TipoPublicacaoValidator>();
            services.AddScoped<PublicacaoValidator>();
            services.AddScoped<IEditoraService, EditoraService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ITipoPublicacaoService, TipoPublicacaoService>();
            services.AddScoped<IPublicacaoService, PublicacaoService>();
            services.AddScoped<IAreaConhecimentoService, AreaConhecimentoService>();
            services.AddScoped<IAutenticarService, AutenticarService>();
            services.AddScoped<IJwtToken, JwtToken>();
        }

        public static void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddSingleton<IMapper>(AutoMapperConfig.Initialize());
            services.AddAutoMapper(typeof(AutoMapperConfig));
        }
    }
}
