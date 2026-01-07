namespace ResponseCachingDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //Adding Response Caching Service
            builder.Services.AddResponseCaching();

            // Adds OpenAPI services using the AddOpenApi extension method on the app builder's service collection.
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            //Adding Response Caching Middleware Components
            app.UseResponseCaching();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}