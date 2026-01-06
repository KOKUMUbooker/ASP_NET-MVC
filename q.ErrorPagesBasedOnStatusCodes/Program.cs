namespace q.ErrorPagesBasedOnStatusCodes;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Re-executes the request with the error code parameter for custom error handling
        app.UseStatusCodePagesWithReExecute("/Error/{0}");

        // app.UseStatusCodePagesWithRedirects("/Error/{0}");

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}