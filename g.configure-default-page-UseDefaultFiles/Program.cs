namespace g.configure_default_page_UseDefaultFiles;

// TODO: Investigate why the I get log for the Use middleware functions even up to the Run Extension
// middleware.
// My expectation is that the request processing pipeline should either stop at UseDefaultFiles() 
// if it not only sets the default file to be served for "/" path but also serves the file
// Alternatively if it only sets the file & UseStaticFiles() servers the set path. the request 
// processing pipeline should end at UseStaticFiles()
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        // Will check the static file directory for files 
        // - index.html, index.htm, default.html or default.htm 
        // and if found specify them to be served if client requests
        // for the root path
        app.UseDefaultFiles();

        app.Use(async(ctx, next) =>
        {
            Console.WriteLine("💣💣💣 The UseDefaultFiles middleware component just got executed");
            await next();
        });
        
        //Adding Static Files Middleware Component to serve the static files
        app.UseStaticFiles();
        
        app.Use(async(ctx, next) =>
        {
            Console.WriteLine("🎃🎃🎃 The UseStaticFiles middleware component just got executed");
            await next();
        });

        //Adding Another Middleware Component to the Request Processing Pipeline
        app.Run(async (context) =>
        {
            Console.WriteLine("🕹️🕹️🕹️ Currently executing the Run Extension terminal middleware function");
            await context.Response.WriteAsync("Request Handled and Response Generated");
        });

        app.Run();
    }
}
