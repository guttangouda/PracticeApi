using Microsoft.EntityFrameworkCore;
using WebApplication1.Modules;
namespace WebApplication1
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
    }
}
