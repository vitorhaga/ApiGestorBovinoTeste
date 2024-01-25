using Microsoft.IdentityModel.Tokens;

namespace ApiGestorBovino.GestorBovino.Models.Entities
{
    public class Pessoas
    {
        public int Codigo { get; set; }
        public DateTime? DataInclusao {  get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public string Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Cnpj { get; set; }
        public string? Telefone { get; set; }

        public Pessoas(string nome, string? cpf, string? cnpj, string? telefone)
        {
            DataInclusao = DateTime.Now;
            DataAlteracao = DateTime.Now;
            Nome = nome;
            Cpf = cpf;
            Cnpj = cnpj;
            Telefone = telefone;
        }
    }
}
