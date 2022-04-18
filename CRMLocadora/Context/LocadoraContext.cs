using CRMLocadora.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMLocadora.Context
{
    public class LocadoraContext : DbContext
    {
      
        public LocadoraContext() 
        {
        }

        public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options) {}

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Locacao> Locacao { get; set; }
        public DbSet<Filme> Filme{ get; set; }
    }
}
