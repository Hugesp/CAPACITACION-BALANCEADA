using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entities.Models;

namespace Entities.Context
{
    public partial class DemoContext : DbContext
    {
        public DemoContext()
        {
        }

        public DemoContext(DbContextOptions<DemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK_ID_CLIENTE");

                entity.ToTable("CLIENTES");

                entity.HasIndex(e => e.Nombre)
                    .HasName("IX_NOMBRE_01");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("ID_CLIENTE")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellidom)
                    .HasColumnName("APELLIDOM")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Apellidop)
                    .HasColumnName("APELLIDOP")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("FECHA_NACIMIENTO")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rfc)
                    .HasColumnName("RFC")
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.HasSequence("SQ_ID_CLIENTE").HasMin(1);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
