


using Microsoft.EntityFrameworkCore;
using RazorCard.Data;
using RazorCard.Repositories.Interfaces;
using  RazorCard.Repositories;
using RazorCard.Services.Interfaces;
using RazorCard.Services;

namespace RazorCard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

       
            builder.Services.AddDbContext<AppDbContext>(
      options => options.UseMySql(
          builder.Configuration.GetConnectionString("DefaultConnection"),
          ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
      ));


            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<IPersonService, PersonService>();

            builder.Services.AddRazorPages();

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();

            app.MapRazorPages();

            app.Run();
        }
    }
}
