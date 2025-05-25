using challenge2.Models;
using Challenge2.Models;
using Microsoft.EntityFrameworkCore;

namespace challenge2.Data
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Moto> Motos { get; set; }

        public DbSet<TipoMoto> TipoMotos { get; set; }

        public DbSet<TipoStatus> TipoStatus { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Moto>()
                .HasOne(m => m.StatusMoto)
                .WithMany(s => s.Motos)
                .HasForeignKey(m => m.StatusMotoId)
                .HasConstraintName("FK_Moto_Status");

            modelBuilder.Entity<Moto>()
                .HasOne(m => m.TipoMoto)
                .WithMany(t => t.Motos)
                .HasForeignKey(m => m.IdTipoMoto)
                .HasConstraintName("FK_Moto_Tipo");

            base.OnModelCreating(modelBuilder);
        }



    }
}
