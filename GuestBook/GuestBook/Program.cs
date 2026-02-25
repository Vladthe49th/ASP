using GuestBook.BLL.Interfaces;
using GuestBook.BLL.Services;
using GuestBook.DAL.Data;
using GuestBook.DAL.Interfaces;
using GuestBook.DAL.Repositories;
using GuestBook.BLL.Services;
using Microsoft.EntityFrameworkCore;
namespace GuestBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IMessageRepository, MessageRepository>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IMessageService, MessageService>();



            var connectionString = builder.Configuration
    .GetConnectionString("GuestBookConnection");



            builder.Services.AddDbContext<GuestBookContext>(options =>
                options.UseMySql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(
                        builder.Configuration.GetConnectionString("DefaultConnection")
                    )
                )
            );


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();


            app.UseAuthorization();

            builder.Services.AddAuthentication("GuestBookCookie")
    .AddCookie("GuestBookCookie", options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.Cookie.Name = "GuestBook.Auth";
    });

            builder.Services.AddAuthorization();


            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
