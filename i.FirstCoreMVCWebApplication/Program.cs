namespace i.FirstCoreMVCWebApplication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add MVC services to the application
        builder.Services.AddControllersWithViews();
        builder.Services.AddMvc();

        var app = builder.Build();

        // Enable routing middleware, which matches incoming HTTP requests to endpoints defined in the application
        app.UseRouting();

        // Map the default controller route (convention: {controller=Home}/{action=Index}/{id?})
        // This means if no specific route is provided, it will default to HomeController and Index action
        // app.MapDefaultControllerRoute();
        
        // Map the default controller route (convention: {controller=Home}/{action=Index}/{id?})
        // This means if no specific route is provided, it will default to HomeController and Index action
        app.MapControllerRoute(
            name: "default", // Name of the route
            pattern: "{controller=Home}/{action=Index}/{id?}" // URL pattern for the route
        );

        // app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}
