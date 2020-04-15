using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JogoProdutoraEF.Models;

namespace JogoProdutoraEF.Data
{
    public class JogoProdutoraContext : DbContext
    {
        public JogoProdutoraContext (DbContextOptions<JogoProdutoraContext> options)
            : base(options)
        {
        }

        public DbSet<JogoProdutoraEF.Models.JogoModel> JogoModel { get; set; }
    }
}
