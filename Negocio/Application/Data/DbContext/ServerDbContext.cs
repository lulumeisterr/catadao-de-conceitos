using Microsoft.EntityFrameworkCore;
namespace Application.Data.ConfigureDbContext
{
    public class ServerDbContext : DbContext
    {
        public DbSet<Server> Server {get; set;}
        public ServerDbContext(DbContextOptions<ServerDbContext> options) : base(options) {}
    }

}