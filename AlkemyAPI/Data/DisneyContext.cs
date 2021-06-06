
using AlkemyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AlkemyAPI.Data
{
    public class DisneyContext : DbContext
    {
        public DisneyContext(DbContextOptions<DisneyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Personaje> Personajes { get; set; }
        public virtual DbSet<Pelicula> Peliculas { get; set; }
        public virtual DbSet<Genero> Generoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genero>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<Pelicula>()
                .Property(e => e.TITULO)
                .IsUnicode(false);

            //modelBuilder.Entity<Pelicula>()
            //    .HasMany(e => e.Personajes)
            //    .WithMany(e => e.Peliculas)
            //    .Map(m => m.ToTable("PersonajesPeliculas").MapLeftKey("ID_Pelicula").MapRightKey("ID_Personaje"));

            modelBuilder.Entity<Personaje>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<Personaje>()
                .Property(e => e.HISTORIA)
                .IsUnicode(false);
        }
    }
}
