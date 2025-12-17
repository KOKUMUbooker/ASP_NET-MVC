using i.DependencyInjection.Models;

namespace i.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddMvc();

        // Adding a service - method 1 -> Using Add() on IServiceCollection
        // builder.Services.Add(new ServiceDescriptor(typeof(IStudentRepository),new StudentRepository(),ServiceLifetime.Singleton));

        // Adding a service - method 2 -> Using an extension method from IServiceCollection eg AddScoped(), AddSingleton(), AddTransient()
        // Extensions approach 1 - Generic overload
        builder.Services.AddSingleton<IStudentRepository,StudentRepository>();
        // Extensions approach 2 - Non-Generic overload
        // builder.Services.AddSingleton(typeof(IStudentRepository),typeof(StudentRepository));

        var app = builder.Build();

        app.UseRouting();
        
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Student}/{action=Index}/{id?}" // URL pattern for the route
        );

        app.Run();
    }
}
