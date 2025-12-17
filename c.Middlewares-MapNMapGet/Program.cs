namespace c.Middlewares_MapNMapGet;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        // Maps HTTP GET requests to the root URL "/" to a method returning "Hello World!"
        app.MapGet("/", () => "Hello World!");
            
        // Maps HTTP GET requests to "/greet" URL to a method returning a greeting message
        app.MapGet("/greet", () => "Hello from the /greet endpoint!");
            
        // Maps HTTP GET requests to "/greet/{name}" URL to a method that uses a route parameter
        app.MapGet("/greet/{name}", (string name) => $"Hello, {name}!");

        app.Run();
    }
}
