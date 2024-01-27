using System.ComponentModel.DataAnnotations;

namespace ApiGestorBovino.GestorBovino.Models.Entities
{
    public class DiagnosticoGestacao
    {
        [Key] public Guid Codigo { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public int NumeroGado { get; set; }
        public int CodigoPessoa { get; set; }
        public int NumeroGadoReprodutor { get; set; }
        public bool Prenha { get; set; }
        public DateTime DataGestacao { get; set; }
        public DiagnosticoGestacao()
        {
        }
    }
}
