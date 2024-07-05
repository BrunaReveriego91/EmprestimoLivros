﻿using AutoMapper;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Mappings.AutoMapperConfig;
using EmprestimoLivros.Application.Services;
using EmprestimoLivros.Infra.Data.Interfaces;
using EmprestimoLivros.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EmprestimoLivros.Infra.IoC
{
    public static class IoCConfiguration
    {
        public static void ConfigureRepository(IServiceCollection services)
        {
            services.AddScoped<IEditoraRepository, EditoraRepository>();
        }

        public static void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<IEditoraService, EditoraService>();
        }

        public static void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddSingleton<IMapper>(AutoMapperConfig.Initialize());
            services.AddAutoMapper(typeof(AutoMapperConfig));
        }
    }
}
