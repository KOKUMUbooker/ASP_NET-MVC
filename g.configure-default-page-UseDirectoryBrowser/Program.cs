namespace g.configure_default_page_UseDirectoryBrowser;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        // Enable directory browsing on the current path
        app.UseDirectoryBrowser();
        
        //Adding Another Middleware Component to the Request Processing Pipeline
        app.Run(async (context) =>
        {
            await context.Response.WriteAsync("Request Handled and Response Generated");
        });

        app.Run();
    }
}
