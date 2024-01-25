namespace ApiGestorBovino.GestorBovino.Models.Entities
{
    public class Fazendas
    {
        public int Codigo { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public string NomeFazenda { get; set; }

        public Fazendas(string nomeFazenda)
        {
            NomeFazenda = nomeFazenda;
            DataInclusao = DateTime.Now;
            DataAlteracao = DateTime.Now;
        }
    }
}
