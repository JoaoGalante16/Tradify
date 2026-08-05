using System.ComponentModel.DataAnnotations;

namespace Tradify.Data.Dtos.PedidoDtos;

public class CreatePedidoDto
{
    [Required(ErrorMessage = "O cliente é obrigatório")]
    public int ClienteId { get; set; }

    public DateTime Data { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "O endereço é obrigatório")]
    [StringLength(200, ErrorMessage = "O endereço não pode passar de 200 caracteres")]
    public string Endereco { get; set; }
}
