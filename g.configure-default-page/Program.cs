namespace g.configure_default_page;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        //Adding Static Files Middleware Component to serve the static files
        app.UseStaticFiles();
        // To access the html file in wwwroot dir, append index.html to the 
        // root url in the browser
        
        //Adding Another Terminal Middleware Component to the Request Processing Pipeline
        app.Run(async (context) =>
        {
            await context.Response.WriteAsync("Request Handled and Response Generated");
        });

        app.Run();
    }
}
