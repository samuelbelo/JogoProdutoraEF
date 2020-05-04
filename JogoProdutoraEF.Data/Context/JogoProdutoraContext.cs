using Microsoft.EntityFrameworkCore;

namespace JogoProdutoraEF.Data
{
    public class JogoProdutoraContext : DbContext
    {
        public JogoProdutoraContext(DbContextOptions<JogoProdutoraContext> options)
            : base(options)
        {
        }

        public DbSet<JogoProdutoraEF.Domain.Models.JogoModel> Jogos { get; set; }
    }
}