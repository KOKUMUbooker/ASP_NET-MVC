using r.EFCoreCodeDemo.Entities;
namespace r.EFCoreCodeDemo;

class Program
{
    static void Main(string[] args)
    {
        using var db = new EFCoreDbContextFactory().CreateDbContext(args);
        Console.WriteLine("Hello, World!");
    }
}
