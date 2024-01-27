using ApiGestorBovino.GestorBovino.Models.Dtos.Requests;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGestorBovino.GestorBovino.Models.Entities
{
    public class Pessoas
    {
        [Column("codigo"),Key] public Guid Codigo { get; set; }
        [Column("data_inclusao")]public DateTime? DataInclusao {  get; set; }
        [Column("data_alteracao")] public DateTime? DataAlteracao { get; set; }
        [Column("data_exclusao")] public DateTime? DataExclusao { get; set; }
        [Column("nome")] public string? Nome { get; set; }
        [Column("cpf")] public string? Cpf { get; set; }
        [Column("cnpj")] public string? Cnpj { get; set; }
        [Column("telefone")] public string? Telefone { get; set; }
        public Pessoas(){}
        public Pessoas(PessoasReq pessoa)
        {
            DataInclusao = DateTime.Now;
            DataAlteracao = DateTime.Now;
            Nome = pessoa.Nome!;
            Cpf = pessoa.Cpf;
            Cnpj = pessoa.Cnpj;
            Telefone = pessoa.Telefone;
        }
    }
}
