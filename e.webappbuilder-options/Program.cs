namespace e.webappbuilder_options;

public class Program
{
    public static void Main(string[] args)
    {
        //Step1: Creating an Instance of WebApplicationOptions Class
        WebApplicationOptions webApplicationOptions = new WebApplicationOptions
        {
            WebRootPath = "MyWebRoot", //Setting the WebRootPath as MyWebRoot
            Args = args, //Setting the Command Line Arguments in Args
            EnvironmentName = "Production", //Changing to Production
        };

        //Step2: Pass WebApplicationOptions Instance to the CreateBuilder Method
        var builder = WebApplication.CreateBuilder(webApplicationOptions);
        var app = builder.Build();
        
        app.MapGet("/", () => $"EnvironmentName: {app.Environment.EnvironmentName} \n" +
        $"ApplicationName: {app.Environment.ApplicationName} \n" +
        $"WebRootPath: {app.Environment.WebRootPath} \n" +
        $"ContentRootPath: {app.Environment.ContentRootPath}");

        app.Run();
    }
}
