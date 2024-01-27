using ApiGestorBovino.GestorBovino.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiGestorBovino.Models.DB;

public class DbContextBusiness : DbContext
{
    public DbSet<Pessoas> Pessoas {get; set;}
    public DbSet<Racas> Racas { get; set;}
    public DbSet<Usuarios> Usuarios { get; set;}
    public DbSet<Fazendas> Fazendas { get; set; }
    public DbSet<CiclosGado> CiclosGado { get; set; }
    public DbSet<DiagnosticoGestacao> DiagnosticoGestacao { get; set; }

#if DEBUG
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-ERL7TQ5;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True");
        base.OnConfiguring(optionsBuilder);
    }
#else
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=tcp:myserver.database.windows.net,1433;Authentication=Active Directory Password;Database=myDataBase;UID=myUser@myDomain;PWD=myPassword;");
        base.OnConfiguring(optionsBuilder);
    };
#endif
}
