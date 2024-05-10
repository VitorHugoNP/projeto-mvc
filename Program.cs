using ProjetoMVC.Models;

namespace ProjetoMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<FilmeRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Filme}/{action=Index}/{id?}");

            app.Run();
        }
    }
}