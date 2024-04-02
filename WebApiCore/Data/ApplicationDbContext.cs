using Microsoft.EntityFrameworkCore;
using WebApiCore.Data.Entities;

namespace WebApiCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SeidlBook\SQLEXPRESS;Database=BancoDados;Integrated Security=True;TrustServerCertificate=True");
            
        }
        public DbSet<Produto> Produto { get; set; }
    }
}
