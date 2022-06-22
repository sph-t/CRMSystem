using CRMSystem;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionstring = builder.Configuration.GetConnectionString("CRMDb");

builder.Services.AddRazorPages();
builder.Services.AddDbContext<CRMDbContext>(options =>
{
    options
        .UseLazyLoadingProxies()
        .UseSqlite("Data Source=CRM.sqlite");
});

//builder.Services.AddDbContext<CRMDbContext>();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.MapRazorPages();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
app.Run();

/***
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CRMSystem
{
   public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}***/
