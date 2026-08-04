namespace Tradify.Models;

public class Pedido
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime Data { get; set; }
    public string Endereco { get; set; }
}
