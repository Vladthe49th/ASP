var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();


app.MapControllers();


app.MapGet("/", () =>
{
    return Results.Redirect("/index.html");
});

app.Run();
