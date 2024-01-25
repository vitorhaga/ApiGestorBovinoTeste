namespace ApiGestorBovino.GestorBovino.Models.Entities
{
    public class Gados
    {
        public Guid Codigo { get; set; }
        public int NumeroGado {  get; set; }
        public int CodigoNumeroGado { get; set;}
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public string Sexo { get; set; }
        public decimal Peso { get; set; }
        public string Ciclo { get; set; }
        public int CodigoPessoa { get; set; }
        public int CodigoRaca { get; set; }
        public int CodigoFazenda { get;set; }

        public Gados(int numeroGado, int codigoNumeroGado, string sexo, decimal peso, string ciclo, int codigoPessoa, int codigoRaca, int codigoFazenda)
        {
            NumeroGado = numeroGado;
            CodigoNumeroGado = codigoNumeroGado;
            Sexo = sexo;
            Peso = peso;
            Ciclo = ciclo;
            CodigoPessoa = codigoPessoa;
            CodigoRaca = codigoRaca;
            CodigoFazenda = codigoFazenda;
            DataInclusao = DateTime.Now;
            DataAlteracao = DateTime.Now;
        }
    }
}
