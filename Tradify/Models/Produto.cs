namespace Tradify.Models;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Valor { get; set; }
    public int Estoque { get; set; }
    public virtual ICollection<ItemPedido> Itens { get; set; }
}
