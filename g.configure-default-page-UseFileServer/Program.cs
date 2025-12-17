using Microsoft.Extensions.FileProviders;

namespace g.configure_default_page_UseFileServer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        // Configure FileServer options for root directory browsing
        var fileServerOptions = new FileServerOptions
        {
            EnableDirectoryBrowsing = true, // Enable directory browsing at the root URL
            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"))
        };
        
        // Clear the default file names to prevent showing the default page
        fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
        
        // Enable Default File, Static File, and Directory Browsing at the root URL
        app.UseFileServer(fileServerOptions);
        
        // Adding Another Middleware Component to the Request Processing Pipeline
        app.Run(async (context) =>
        {
            await context.Response.WriteAsync("Request Handled and Response Generated");
        });

        app.Run();
    }
}
