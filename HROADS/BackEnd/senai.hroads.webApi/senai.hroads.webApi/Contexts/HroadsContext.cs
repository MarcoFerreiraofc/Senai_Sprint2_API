using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai.hroads.webApi.Domains;

#nullable disable

namespace senai.hroads.webApi.Contexts
{
    public partial class HroadsContext : DbContext
    {
        public HroadsContext()
        {
        }

        public HroadsContext(DbContextOptions<HroadsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<HabilidadesClasse> HabilidadesClasses { get; set; }
        public virtual DbSet<Personagem> Personagems { get; set; }
        public virtual DbSet<TipoHabilidade> TipoHabilidades { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-4A3IQMH\\SQLEXPRESS; initial catalog=SENAI_HROADS_TARDE; user=sa; pwd=senai@132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Classe>(entity =>
            {
                entity.HasKey(e => e.IdClasse)
                    .HasName("PK__Classe__60FFF801C9958E44");

                entity.ToTable("Classe");

                entity.HasIndex(e => e.NomeClasse, "UQ__Classe__36F040DB134F16E6")
                    .IsUnique();

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.NomeClasse)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PK__Habilida__655F7528C8DF65D3");

                entity.ToTable("Habilidade");

                entity.HasIndex(e => e.NomeHabilidade, "UQ__Habilida__206452FF97A73EC7")
                    .IsUnique();

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.Property(e => e.IdTipoHabilidade).HasColumnName("idTipoHabilidade");

                entity.Property(e => e.NomeHabilidade)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoHabilidadeNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdTipoHabilidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Habilidad__idTip__412EB0B6");
            });

            modelBuilder.Entity<HabilidadesClasse>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HabilidadesClasse");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdClasse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Habilidad__idCla__4316F928");

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdHabilidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Habilidad__idHab__440B1D61");
            });

            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.HasKey(e => e.IdPersonagem)
                    .HasName("PK__Personag__E175C72E946E668F");

                entity.ToTable("Personagem");

                entity.HasIndex(e => e.NomePersonagem, "UQ__Personag__84C7E40CE1C56778")
                    .IsUnique();

                entity.Property(e => e.IdPersonagem).HasColumnName("idPersonagem");

                entity.Property(e => e.DataAtualizacao).HasColumnType("date");

                entity.Property(e => e.DataCriacao).HasColumnType("date");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.NomePersonagem)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.Personagems)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__Personage__idCla__3A81B327");
            });

            modelBuilder.Entity<TipoHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdTipoHabilidade)
                    .HasName("PK__TipoHabi__B197B83215B2DE90");

                entity.ToTable("TipoHabilidade");

                entity.HasIndex(e => e.TipoHabilidade1, "UQ__TipoHabi__3ABE239DF21D6370")
                    .IsUnique();

                entity.Property(e => e.IdTipoHabilidade).HasColumnName("idTipoHabilidade");

                entity.Property(e => e.TipoHabilidade1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TipoHabilidade");
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TiposUsu__03006BFFF1A6B4DF");

                entity.ToTable("TiposUsuario");

                entity.HasIndex(e => e.Titulo, "UQ__TiposUsu__7B406B565B35B1CA")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A66446C364");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Email, "UQ__Usuario__AB6E61644FDD99F4")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__idTipoU__5DCAEF64");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
