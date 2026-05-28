using Microsoft.EntityFrameworkCore;
using RestauranteApi.Models;

namespace RestauranteApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<PratosModel> Prato { get; set; }
    }
}
