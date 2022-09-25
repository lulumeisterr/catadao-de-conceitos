using Microsoft.EntityFrameworkCore;
namespace Application.Data.NegocioDbContext
{
    public class NegocioDbContext : DbContext
    {
        public DbSet<Negocio> Negocio {get; set;}
        public NegocioDbContext(DbContextOptions<NegocioDbContext> options) : base(options) {}
    }

}