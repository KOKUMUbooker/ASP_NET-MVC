namespace c.Middlewares_Run;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        // Configuring New Inline Middleware Component using Run Extension Method
        app.Run(FirstMiddleware);

        // This 2nd Run middleware never gets executed since Run middlewares are 
        // terminal middleware components ie the first one will not call the subsequent
        // middleware
        app.Run(async (context) =>
        {
            await context.Response.WriteAsync("Getting Response from Second Middleware");
        });

        app.Run();
    }

    //This method signature must be the same as the RequestDelegate signature
    private static async Task FirstMiddleware(HttpContext context)
    {
        //Using context object, we can access both Request and Response
        await context.Response.WriteAsync("Getting Response from First Middleware");
    }
}
