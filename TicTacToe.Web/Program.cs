using TicTacToe.Web.Extensions;

namespace TicTacToe.Web;

internal class Program
{
    private static void Main()
    {
        var builder = WebApplication.CreateBuilder();

        builder.Configuration.AddJsonFile("auth_options.json");
        var jwtSecretKey = builder.Configuration["jwtSecretKey"]!.ToString();
        builder.Services.AddJwtBearerAuthentication(jwtSecretKey!);
        builder.Services.AddSignalR();
        builder.Services.AddCors();

        var app = builder.Build();
        app.UseCors(options => options
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .SetIsOriginAllowed((host) => true)
                   .AllowCredentials());

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors();
        app.Run();
    }
}
