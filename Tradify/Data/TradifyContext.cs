using Microsoft.EntityFrameworkCore;
using Tradify.Models;

namespace Tradify.Data
{
    public class TradifyContext : DbContext
    {
        public TradifyContext(DbContextOptions<TradifyContext> opts): base(opts)
        {
            
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
