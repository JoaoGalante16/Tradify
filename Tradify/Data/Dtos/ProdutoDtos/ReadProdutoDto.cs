using Tradify.Data.Dtos.ItemPedidoDtos;

namespace Tradify.Data.Dtos.ProdutoDtos;

public class ReadProdutoDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Valor { get; set; }
    public int Estoque { get; set; }
    public virtual ICollection<ReadItemPedidoDto> Itens { get; set; }
}
