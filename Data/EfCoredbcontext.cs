using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using saurav.Entities;

namespace saurav.Data
{
    public class EfCoreDbcontext : DbContext
    {
        public EfCoreDbcontext(DbContextOptions<EfCoreDbcontext> options) : base(options)
        {
        }

        public DbSet<Student> Students {get;set;}
        public DbSet<Course> Courses {get;set;}
        
        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
    
}
