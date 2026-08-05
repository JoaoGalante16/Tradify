using Tradify.Data.Dtos.ClienteDtos;
using Tradify.Data.Dtos.ItemPedidoDtos;
using Tradify.Models;

namespace Tradify.Data.Dtos.PedidoDtos;

public class ReadPedidoDto
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime Data { get; set; }
    public string Endereco { get; set; }
    public virtual ICollection<ReadItemPedidoDto> Itens { get; set; }
}
