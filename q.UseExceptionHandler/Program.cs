namespace q.UseExceptionHandler;

public class Program
{
    public static void Main(string[] args)
    {
        var webAppOptions = new WebApplicationOptions
        {
            EnvironmentName = "Staging", // Change Env to staging to force Error handling to use UseExceptionHandler
            Args = args
        };
        var builder = WebApplication.CreateBuilder(webAppOptions);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();
        
        Console.WriteLine($"Env : {app.Environment.EnvironmentName}");
        Console.WriteLine($"Env is Dev : {app.Environment.IsDevelopment()}");
        Console.WriteLine($"Env is stg : {app.Environment.IsStaging()}");
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // This will handle exceptions and redirect to the specified error page.
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseHttpsRedirection();
        app.UseRouting();

        // app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}
