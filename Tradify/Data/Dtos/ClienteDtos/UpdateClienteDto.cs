using System.ComponentModel.DataAnnotations;

namespace Tradify.Data.Dtos.ClienteDtos;

public class UpdateClienteDto
{
    [Required(ErrorMessage = "O nome do cliente é obrigatório")]
    [StringLength(100, ErrorMessage = "O nome não pode passar de 100 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 dígitos")]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
    public string Email { get; set; }
}
