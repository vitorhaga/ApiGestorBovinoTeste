using System.ComponentModel.DataAnnotations;

namespace ApiGestorBovino.GestorBovino.Models.Entities
{
    public class Gados
    {
        [Key] public Guid Codigo { get; set; }
        public int NumeroGado {  get; set; }
        public int CodigoNumeroGado { get; set;}
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public string? Sexo { get; set; }
        public decimal? Peso { get; set; }
        public string? Ciclo { get; set; }
        public int CodigoPessoa { get; set; }
        public int CodigoRaca { get; set; }
        public int CodigoFazenda { get;set; }
        public Gados()
        {
        }
        public Gados(Gados gado)
        {
            NumeroGado = gado.NumeroGado;
            CodigoNumeroGado = gado.CodigoNumeroGado;
            Sexo = gado.Sexo;
            Peso = gado.Peso;
            Ciclo = gado.Ciclo;
            CodigoPessoa = gado.CodigoPessoa;
            CodigoRaca = gado.CodigoRaca;
            CodigoFazenda = gado.CodigoFazenda;
            DataInclusao = DateTime.Now;
            DataAlteracao = DateTime.Now;
        }
    }
}
