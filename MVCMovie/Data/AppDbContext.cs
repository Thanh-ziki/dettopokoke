using Microsoft.EntityFrameworkCore;
using MVCMovie.Models;

namespace MVCMovie.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet for PersonClass model
        public DbSet<PersonClass> People { get; set; }
        public DbSet<MVCMovie.Models.Student> Student { get; set; } = default!;
        public DbSet<MVCMovie.Models.Create> Create { get; set; } = default!;
    }
}
