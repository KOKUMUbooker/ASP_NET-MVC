using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace r.EFCoreCodeFirstDemo.Entities
{
    public class EFCoreDbContextFactory
        : IDesignTimeDbContextFactory<EFCoreDbContext>
    {
        public EFCoreDbContext CreateDbContext(string[] args)
        {  
            // 1. Read connection string from appsettings.json file 
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json") // Specify the configuration file to load.
                .Build(); // Build the configuration object, making it ready to retrieve values.
            var configSection = configBuilder.GetSection("ConnectionStrings");
            var connectionString = configSection["SQLServerConnection"] ?? null;

            // 2. Use read connection string to connect to SQL database
            var optionsBuilder = new DbContextOptionsBuilder<EFCoreDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            // Enable logging
            optionsBuilder.LogTo(Console.WriteLine,LogLevel.Information);

            return new EFCoreDbContext(optionsBuilder.Options);
        }
    }
}
