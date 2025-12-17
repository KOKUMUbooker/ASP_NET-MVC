namespace c.Middlewares_Use;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        //Configuring Middleware Component using Use and Run Extension Method

        //First Middleware Component Registered using Use Extension Method
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("Middleware1: Incoming Request\n");
            //Calling the Next Middleware Component
            await next();
        });

        //Second Middleware Component Registered using Run Extension Method
        app.Run(async (context) =>
        {
            await context.Response.WriteAsync("Middleware2: Incoming Request handled and response generated\n");
            //Terminal Middleware Component i.e. cannot call the Next Component
        });

        //This will Start the Application
        app.Run();
    }
}
