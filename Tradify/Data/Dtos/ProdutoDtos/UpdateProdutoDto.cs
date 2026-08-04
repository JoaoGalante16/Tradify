using System.ComponentModel.DataAnnotations;

namespace Tradify.Data.Dtos.ProdutoDtos;

public class UpdateProdutoDto
{
    [Required(ErrorMessage = "O nome do produto é obrigatório")]
    [StringLength(50, ErrorMessage = "O nome do produto não pode passar de 50 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O valor do produto é obrigatório")]
    [Range(0, double.MaxValue, ErrorMessage = "O valor não pode ser menor que 0")]
    public double Valor { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "O estoque não pode ser menor que 0")]
    public int Estoque { get; set; }
}
