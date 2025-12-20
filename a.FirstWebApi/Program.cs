namespace FirstWebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");
        app.MapGet("/process", () => "Worker Process Name : " + System.Diagnostics.Process.GetCurrentProcess().ProcessName);

        app.Run();
    }
}
