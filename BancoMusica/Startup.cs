using BancoMusica.Data;
using BancoMusica.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BancoMusica
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
            services.AddControllersWithViews();

            services.AddMvc();
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<BancoMusicaContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DataBase")));


            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddSingleton<IUsuarioRepositorio, UsuarioRepositorio>();
          
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            
           
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
    }
}
