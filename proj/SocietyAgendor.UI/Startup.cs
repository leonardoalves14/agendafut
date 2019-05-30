using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocietyAgendor.UI.Concrete;
using SocietyAgendor.UI.Service;

namespace SocietyAgendor.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IFuncionarioService, FuncionarioService>();
            services.AddTransient<IEstabelecimentoService, EstabelecimentoService>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<ICargoService, CargoService>();
            services.AddTransient<IHorarioService, HorarioService>();
            services.AddTransient<IDiaSemanaService, DiaSemanaService>();
            services.AddTransient<IAgendamentoService, AgendamentoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
