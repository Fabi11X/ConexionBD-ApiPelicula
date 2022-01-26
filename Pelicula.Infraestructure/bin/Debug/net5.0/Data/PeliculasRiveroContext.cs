using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pelicula.Infraestructure.Repositories;
using Pelicula.Domain.Entities;

#nullable disable

namespace Pelicula.Infraestructure.Data
{
    public partial class PeliculasRiveroContext : DbContext
    {
        public PeliculasRiveroContext()
        {
        }

        public PeliculasRiveroContext(DbContextOptions<PeliculasRiveroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=PeliculasRivero.mssql.somee.com;Initial Catalog=PeliculasRivero;Persist Security Info=False;User ID=RiveroX_SQLLogin_1;Password=6ns17g2p2x");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.IdPelicula);

                entity.ToTable("Movie");

                entity.Property(e => e.IdPelicula).HasColumnName("idPelicula");

                entity.Property(e => e.DirectorPelicula)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("directorPelicula");

                entity.Property(e => e.GeneroPelicula)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("generoPelicula");

                entity.Property(e => e.PubliPelicula)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("publiPelicula");

                entity.Property(e => e.PuntuacionPelicula).HasColumnName("puntuacionPelicula");

                entity.Property(e => e.RatingPelicula).HasColumnName("ratingPelicula");

                entity.Property(e => e.TituloPelicula)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tituloPelicula");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
