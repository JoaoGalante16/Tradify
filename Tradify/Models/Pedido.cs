using Tradify.Data.Dtos.ItemPedidoDtos;

namespace Tradify.Models;

public class Pedido
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public virtual Cliente Cliente { get; set; }
    public DateTime Data { get; set; }
    public string Endereco { get; set; }
    public virtual ICollection<ItemPedido> Itens { get; set; }
}
