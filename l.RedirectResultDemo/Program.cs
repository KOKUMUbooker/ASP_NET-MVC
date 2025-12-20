namespace l.RedirectResultDemo;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();

        //URL Pattern: about
        app.MapControllerRoute(
            name: "AboutRoute",
            pattern: "about",
            defaults: new { controller = "Home", action = "About" }
        );

        //URL Pattern: about2
        app.MapControllerRoute(
            name: "AboutRoute2",
            pattern: "about2",
            defaults: new { controller = "Home", action = "About2" }
        );

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}
