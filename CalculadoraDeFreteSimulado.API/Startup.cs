using CalculadoraDeFreteSimulado.API.Context;
using CalculadoraDeFreteSimulado.API.Contracts;
using CalculadoraDeFreteSimulado.API.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CalculadoraDeFreteSimulado.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region Context

            // Foram utilizados 3 contextos separados para simular as bases/servicos diferentes que o programa acessaria/consumiria

            services.AddDbContext<CalculoFreteContext>(opt =>
                opt.UseInMemoryDatabase("CalculoFreteContext"));

            services.AddDbContext<NegociacaoFreteContext>(opt =>
                opt.UseInMemoryDatabase("NegociacaoFreteContext"));

            services.AddDbContext<EmbarqueContext>(opt =>
                opt.UseInMemoryDatabase("EmbarqueContext"));

            #endregion

            #region Repositories

            services.AddScoped<ICalculoFreteRepository, CalculoFreteRepository>();

            #endregion

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
