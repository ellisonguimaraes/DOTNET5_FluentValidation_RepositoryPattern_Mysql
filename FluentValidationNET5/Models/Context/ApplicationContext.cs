using Microsoft.EntityFrameworkCore;

namespace FluentValidationNET5.Models.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        { }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }

        public DbSet<Student> Students { get; set; }
    }
}