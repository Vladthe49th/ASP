using Microsoft.AspNetCore.Builder;
using Scalar.AspNetCore;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                app.MapOpenApi();

                app.MapScalarApiReference();
            }

            app.MapScalarApiReference(options =>

            {
                options.Title = "API студентів";
                options.WithTheme(ScalarTheme.Alternate);
            }
                );

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}