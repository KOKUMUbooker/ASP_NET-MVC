using Microsoft.AspNetCore.Localization; // Namespace for localization middleware
using System.Globalization; // Namespace for culture-related information

namespace n.DisplayNDisplayFormatAttributes;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a builder for setting up and configuring the web application.
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Registers MVC controllers with views support
        builder.Services.AddControllersWithViews();

        // Define the list of supported cultures
        // Define the list of supported cultures (locales) for the application.
        // Supported cultures are represented by CultureInfo objects
        // en-US (United States), en-GB (United Kingdom), and en-IN (India).
        var supportedCultures = new[]
        {
            new CultureInfo("en-US"), // English (United States)
            new CultureInfo("en-GB"), // English (United Kingdom)
            new CultureInfo("en-KE"), // English (Kenya)
        };

        // Configure localization options for the application.
        // This includes setting the default culture, supported cultures, and how to detect the culture.

        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            // Set the default request culture.
            // If no specific culture is provided by the user, the app will use "en-US" (US English).
            options.DefaultRequestCulture = new RequestCulture("en-KE");

            // Specify the list of cultures supported by the app.
            // SupportedCultures specifies which cultures can be used to format data.
            options.SupportedCultures = supportedCultures;

            // Specify supported UI cultures.
            // SupportedUICultures defines the languages the application’s UI can support.
            options.SupportedUICultures = supportedCultures;
        });

        // Build the application based on the configured services
        var app = builder.Build();

        // Enable localization middleware to process requests based on the configured cultures
        // This middleware will check each request and apply the appropriate culture (language and formatting)
        // based on the settings provided in the localization configuration.
        app.UseRequestLocalization();

        //Check if the environment is not "Development".
        // If the app is not in development mode, it uses a custom error page and enforces HTTP Strict Transport Security (HSTS).
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error"); // Use a custom error page for exceptions.
            app.UseHsts(); // Enforces HTTPS for secure communication.
        }

        // Redirect HTTP requests to HTTPS
        app.UseHttpsRedirection(); // Enforces secure communication by redirecting HTTP to HTTPS.

        // Serve static files like CSS, JavaScript, and images from the "wwwroot" folder.
        app.UseStaticFiles(); // Enables serving static files.

        // Set up the routing system for the application.
        app.UseRouting(); // Defines how the app handles URLs and routes requests to the appropriate controllers and actions.

        // Enable authorization middleware (not configured in this example)
        app.UseAuthorization();

        // Define the default route for the MVC application.
        // This maps a URL pattern to a controller (Employee), an action (Details), and optionally an id parameter.
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Employee}/{action=Details}/{id?}");

        // Run the application and start listening for HTTP requests.
        app.Run(); // Starts the web server to handle incoming requests.
    }
}