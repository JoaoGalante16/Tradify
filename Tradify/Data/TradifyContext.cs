using Microsoft.EntityFrameworkCore;
using Tradify.Models;

namespace Tradify.Data
{
    public class TradifyContext : DbContext
    {
        public TradifyContext(DbContextOptions<TradifyContext> opts) : base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ItemPedido>()
                 .HasKey(item => new { item.PedidoId, item.ProdutoId });

            builder.Entity<ItemPedido>()
                .HasOne(item => item.Pedido)
                .WithMany(pedido => pedido.Itens)
                .HasForeignKey(item => item.PedidoId);

            builder.Entity<ItemPedido>()
                .HasOne(item => item.Produto)
                .WithMany(produto => produto.Itens)
                .HasForeignKey(item => item.ProdutoId);
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }
    }
}
