using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoBRQ.Application.Contracts;
using ProjetoBRQ.Application.Services;
using ProjetoBRQ.Domain.Contracts.Repositories;
using ProjetoBRQ.Domain.Contracts.Services;
using ProjetoBRQ.Domain.Services;
using ProjetoBRQ.Infra.Data.Contexts;
using ProjetoBRQ.Infra.Data.Repositories;

namespace ProjetoBRQ.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. 
        // Use this method to add services to the container.
        // For more information on how to configure your application, 
        // visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //habilitar o projeto para MVC
            services.AddControllersWithViews();

            #region Configuração do EntityFramework

            services.AddDbContext<DataContext>
                (options => options.UseSqlServer
                (Configuration.GetConnectionString("ProjetoBRQ")));

            #endregion

            #region Configuração de injeção de dependência (inicialização)

            services.AddTransient<IUsuarioApplicationService,
                                   UsuarioApplicationService>();
            services.AddTransient<IUsuarioDomainService,
                                   UsuarioDomainService>();
            services.AddTransient<IUsuarioRepository,
                                   UsuarioRepository>();

            #endregion
        }

        // This method gets called by the runtime. 
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //habilitar o uso da pasta /wwwroot
            app.UseStaticFiles();

            //configurando a página inicial do projeto
            app.UseEndpoints(endpoints => //VS2019
            {
                //mapear a página inicial do projeto (default)
                endpoints.MapControllerRoute(
                    name: "default", //página padrão
                    pattern: "{controller=Home}/{action=Index}"
                );
            });

        }

    }

}
