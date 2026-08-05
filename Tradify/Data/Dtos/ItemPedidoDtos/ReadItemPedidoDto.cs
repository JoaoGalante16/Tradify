namespace Tradify.Data.Dtos.ItemPedidoDtos
{
    public class ReadItemPedidoDto
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
    }
}
