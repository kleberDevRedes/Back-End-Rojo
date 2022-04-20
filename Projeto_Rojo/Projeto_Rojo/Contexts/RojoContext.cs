using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Projeto_Rojo.Domains;

#nullable disable

namespace Projeto_Rojo.Contexts
{
    public partial class RojoContext : DbContext
    {
        public RojoContext()
        {
        }

        public RojoContext(DbContextOptions<RojoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alertum> Alerta { get; set; }
        public virtual DbSet<Alteracao> Alteracaos { get; set; }
        public virtual DbSet<Equipamento> Equipamentos { get; set; }
        public virtual DbSet<ImgEquipamento> ImgEquipamentos { get; set; }
        public virtual DbSet<ImgUsuario> ImgUsuarios { get; set; }
        public virtual DbSet<TipoEquipamento> TipoEquipamentos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=dbprojeto-rojo.ca4n6cmzyivn.us-east-1.rds.amazonaws.com; initial catalog=PROJETO_ROJO; user id=Desenvolvedor; pwd=Senai#Grupo11;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Alertum>(entity =>
            {
                entity.HasKey(e => e.IdAlerta)
                    .HasName("PK__Alerta__D2CDBC4FF14F42E3");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEquipamentoNavigation)
                    .WithMany(p => p.Alerta)
                    .HasForeignKey(d => d.IdEquipamento)
                    .HasConstraintName("FK__Alerta__IdEquipa__49C3F6B7");
            });

            modelBuilder.Entity<Alteracao>(entity =>
            {
                entity.HasKey(e => e.IdAlteracao)
                    .HasName("PK__Alteraca__76DD1CC1AD18CB2C");

                entity.ToTable("Alteracao");

                entity.Property(e => e.DataAlteracao).HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEquipamentoNavigation)
                    .WithMany(p => p.Alteracaos)
                    .HasForeignKey(d => d.IdEquipamento)
                    .HasConstraintName("FK__Alteracao__IdEqu__5AEE82B9");
            });

            modelBuilder.Entity<Equipamento>(entity =>
            {
                entity.HasKey(e => e.IdEquipamento)
                    .HasName("PK__Equipame__E309D87F83948D22");

                entity.ToTable("Equipamento");

                entity.Property(e => e.DataEntrada).HasColumnType("date");

                entity.Property(e => e.Descricao).HasColumnType("text");

                entity.Property(e => e.Dns).HasColumnName("DNS");

                entity.Property(e => e.Modelo)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoEquipamentoNavigation)
                    .WithMany(p => p.Equipamentos)
                    .HasForeignKey(d => d.IdTipoEquipamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipamen__IdTip__46E78A0C");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Equipamentos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Equipamen__IdUsu__45F365D3");
            });

            modelBuilder.Entity<ImgEquipamento>(entity =>
            {
                entity.HasKey(e => e.IdImagemEquipamento)
                    .HasName("PK__ImgEquip__739FE4ADF20E1C54");

                entity.ToTable("ImgEquipamento");

                entity.Property(e => e.Binario)
                    .IsRequired()
                    .HasColumnName("binario");

                entity.Property(e => e.DataInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("data_inclusao")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mimeType");

                entity.Property(e => e.NomeArquivo)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nomeArquivo");

                entity.HasOne(d => d.IdEquipamentoNavigation)
                    .WithMany(p => p.ImgEquipamentos)
                    .HasForeignKey(d => d.IdEquipamento)
                    .HasConstraintName("FK__ImgEquipa__IdEqu__4CA06362");
            });

            modelBuilder.Entity<ImgUsuario>(entity =>
            {
                entity.HasKey(e => e.IdImg)
                    .HasName("PK__ImgUsuar__0C1AF99B648FC5A5");

                entity.ToTable("ImgUsuario");

                entity.HasIndex(e => e.IdUsuario, "UQ__ImgUsuar__5B65BF961C4E4762")
                    .IsUnique();

                entity.Property(e => e.Binario)
                    .IsRequired()
                    .HasColumnName("binario");

                entity.Property(e => e.DataInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("data_inclusao")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mimeType");

                entity.Property(e => e.NomeArquivo)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nomeArquivo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.ImgUsuario)
                    .HasForeignKey<ImgUsuario>(d => d.IdUsuario)
                    .HasConstraintName("FK__ImgUsuari__IdUsu__3D5E1FD2");
            });

            modelBuilder.Entity<TipoEquipamento>(entity =>
            {
                entity.HasKey(e => e.IdTipoEquipamento)
                    .HasName("PK__TipoEqui__0191D191A9BE2A3C");

                entity.ToTable("TipoEquipamento");

                entity.HasIndex(e => e.Equipamento, "UQ__TipoEqui__3185A02D2B9455AE")
                    .IsUnique();

                entity.Property(e => e.Equipamento)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__CA04062BABD3D77C");

                entity.ToTable("TipoUsuario");

                entity.HasIndex(e => e.Usuario, "UQ__TipoUsua__E3237CF7AD80DECE")
                    .IsUnique();

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97C92FBC7E");

                entity.ToTable("Usuario");

                entity.Property(e => e.Cargo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Contato)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__IdTipoU__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
