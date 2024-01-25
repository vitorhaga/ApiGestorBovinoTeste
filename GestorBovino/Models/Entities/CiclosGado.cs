namespace ApiGestorBovino.GestorBovino.Models.Entities
{
    public class CiclosGado
    {
        public int Codigo { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public string Descricao { get; set; }
        public DateTime? TempoProximoCiclo { get; set; }

        public CiclosGado(string descricao, DateTime? tempoProximoCiclo)
        {
            DataInclusao = DateTime.Now;
            DataAlteracao = DateTime.Now;
            Descricao = descricao;
            if (tempoProximoCiclo.HasValue)
                TempoProximoCiclo = tempoProximoCiclo;
            else
                TempoProximoCiclo = DateTime.Now.AddMonths(6);
        }
    }
}
