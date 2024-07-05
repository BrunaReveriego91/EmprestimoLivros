using EmprestimoLivros.Infra.Data.Configuration;
using EmprestimoLivros.Infra.IoC;

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
            }
            else
            {
                // Middleware de tratamento de erro para outros ambientes (produção, staging, etc.).
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // Middleware para redirecionar todas as requisições HTTP para HTTPS, se necessário.
            app.UseHttpsRedirection();

            // Middleware para servir arquivos estáticos (por exemplo, HTML, CSS, imagens).
            app.UseStaticFiles();

            // Middleware para roteamento de requisições HTTP.
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
