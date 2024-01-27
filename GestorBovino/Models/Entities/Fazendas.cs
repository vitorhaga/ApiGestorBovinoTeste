using System.ComponentModel.DataAnnotations;

namespace ApiGestorBovino.GestorBovino.Models.Entities
{
    public class Fazendas
    {
        [Key] public Guid Codigo { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public string? NomeFazenda { get; set; }
        public Fazendas()
        {
        }
        public Fazendas(string nomeFazenda)
        {
            NomeFazenda = nomeFazenda;
            DataInclusao = DateTime.Now;
            DataAlteracao = DateTime.Now;
        }
    }
}
