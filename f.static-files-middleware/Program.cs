namespace f.static_files_middleware;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        // Add static files middleware component
        app.UseStaticFiles();
        
        // // Example use for setting configuration options for 
        // // how static files are to be served
        // app.UseStaticFiles(
        //     new StaticFileOptions
        //     {
        //         OnPrepareResponse = ctx =>
        //         {
        //             // Cache static files for 30 days
        //             ctx.Context.Response.Headers["Cache-Control"] = "public,max-age=2592000";
        //         }
        //     }
        // );

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}
