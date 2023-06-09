namespace TicTacToe.Web;

internal class Program
{
    private static void Main()
    {
        var builder = WebApplication.CreateBuilder();
        var app = builder.Build();

        app.Run();
    }
}
