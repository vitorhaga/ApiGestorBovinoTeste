namespace ApiGestorBovino.GestorBovino.Models.Entities
{
    public class Usuarios
    {
        public int Codigo { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public int CodigoPessoa { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Administrador { get; set; }
        public Usuarios(int codigoPessoa, string login, string senha, bool administrador)
        {
            CodigoPessoa = codigoPessoa;
            Login = login;
            Senha = senha;
            Administrador = administrador;
        }
    }
}
