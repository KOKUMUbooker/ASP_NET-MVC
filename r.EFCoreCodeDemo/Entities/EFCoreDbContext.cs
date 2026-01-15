using Microsoft.EntityFrameworkCore;
using r.EFCoreCodeDemo.Entities;

namespace r.EFCoreCodeDemo.Entities
{
    public class EFCoreDbContext : DbContext
    {

        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options)
        : base(options) // The base(options) call passes the options to the base DbContext class constructor.
        {
        }
        // DbSet properties represent the tables in the database. 
        // Each DbSet corresponds to a table, and the type parameter corresponds to the entity class mapped to that table.
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}