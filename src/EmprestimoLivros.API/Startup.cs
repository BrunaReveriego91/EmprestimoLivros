using EmprestimoLivros.Infra.Data.Configuration;
using EmprestimoLivros.Infra.IoC;
using Microsoft.OpenApi.Models;

namespace EmprestimosLivros.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });
            });


            services.Configure<MongoConfiguration>(
              Configuration.GetSection("MongoSettings"));

            IoCConfiguration.ConfigureRepository(services);
            IoCConfiguration.ConfigureService(services);
            IoCConfiguration.ConfigureAutoMapper(services);


        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Página de exceção detalhada para ambiente de desenvolvimento.
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
                });

            }
            else
            {
               
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            // Middleware para autorização (por exemplo, autenticação de usuário).
            app.UseAuthorization();

            // Middleware para endpoint de controle de ações (por exemplo, MVC controllers).
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Mapeia os controllers MVC.
            });
        }

    }
}
