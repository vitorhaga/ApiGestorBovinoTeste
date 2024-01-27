using System.ComponentModel.DataAnnotations;

namespace ApiGestorBovino.GestorBovino.Models.Entities
{
    public class Usuarios
    {
        [Key] public Guid Codigo { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public int CodigoPessoa { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public bool Administrador { get; set; }
        public Usuarios() { }
        public Usuarios(Usuarios usuario)
        {
            CodigoPessoa = usuario.CodigoPessoa;
            Login = usuario.Login;
            Senha = usuario.Senha;
            Administrador = usuario.Administrador;
        }
    }
}
