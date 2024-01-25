namespace ApiGestorBovino.GestorBovino.Models.Entities
{
    public class Racas
    {
        public int Codigo { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public string NomeRaca{ get; set; }

        public Racas(string nomeRaca)
        {
            NomeRaca = nomeRaca;
            DataInclusao = DateTime.Now;
            DataAlteracao = DateTime.Now;
        }
    }
}
