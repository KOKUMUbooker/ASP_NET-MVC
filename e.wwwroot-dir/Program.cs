namespace e.wwwroot_dir;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        //Adding Static Files Middleware Component to serve the static files
        app.UseStaticFiles();

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}
