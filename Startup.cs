using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace CRMSystem
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) => _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("CRMDb");
            services.AddRazorPages();
            services.AddDbContext<CRMDbContext>(optionsBuilder =>
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlite(connectionString));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940if (env.IsDevelopment())
            /***{
                app.UseDeveloperExceptionPage();
            }***/

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
