namespace d.Request_Processing_Pipeline;

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
            await context.Response.WriteAsync("Middleware1: Outgoing Response\n");
        });

        //Second Middleware Component Registered using Use Extension Method
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("Middleware2: Incoming Request\n");
            //Calling the Next Middleware Component
            await next();
            await context.Response.WriteAsync("Middleware2: Outgoing Response\n");
        });

        //Third Middleware Component Registered using Run Extension Method
        app.Run(async (context) =>
        {
            await context.Response.WriteAsync("Middleware3: Incoming Request handled and response generated\n");
            //Terminal Middleware Component i.e. cannot call the Next Component
        });

        //This will Start the Application
        app.Run();
    }
}
