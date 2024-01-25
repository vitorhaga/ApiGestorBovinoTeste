using ApiGestorBovino.GestorBovino.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiGestorBovino.Models.DB
{
    public class DbContextBusiness : DbContext
    {
        DbSet<Pessoas> Pessoas {get; set;}

#if DEBUG
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-ERL7TQ5;Initial Catalog=master;Integrated Security=true;");
            base.OnConfiguring(optionsBuilder);
        }
#else
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:myserver.database.windows.net,1433;Authentication=Active Directory Integrated;Database=mydatabase;");
            base.OnConfiguring(optionsBuilder);
        };
#endif
    }
}
