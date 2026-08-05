using Tradify.Data.Dtos.PedidoDtos;
using Tradify.Models;

namespace Tradify.Data.Dtos.ClienteDtos;

public class ReadClienteDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public virtual ICollection<ReadPedidoDto> Pedidos { get; set; }
}
