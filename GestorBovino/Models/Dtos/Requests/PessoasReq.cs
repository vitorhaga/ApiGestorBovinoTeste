using System.ComponentModel.DataAnnotations;

namespace ApiGestorBovino.GestorBovino.Models.Dtos.Requests;
public record PessoasReq()
{
    [Required]public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public string? Cnpj { get; set; }
    public string? Telefone { get; set; }
};
