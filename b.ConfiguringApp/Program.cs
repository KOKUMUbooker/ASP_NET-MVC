namespace b.ConfiguringApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // Log args 
            foreach(string arg in args)
            {
                Console.Write($"{arg} ,");
            }

            //ConfigurationManager configuration = builder.Configuration;

            //Get the Configuration Value using Generic GetValue
            string? MyCustomKeyValue1 = builder.Configuration.GetValue<string>("MyCustomKey", "DefaultValue");

            //Get the Configuration Value using Indexer
            string? MyCustomKeyValue = builder.Configuration["MyCustomKey"];

            app.MapGet("/", () => $"{MyCustomKeyValue}");

            app.Run();
        }
    }
}