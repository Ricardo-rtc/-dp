using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SP_Medical.webApi.Domains;

#nullable disable

namespace SP_Medical.webApi.Contexts
{
    public partial class SpMedicalContext : DbContext
    {
        public SpMedicalContext()
        {
        }

        public SpMedicalContext(DbContextOptions<SpMedicalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Consultum> Consulta { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source = NOTE0113I2\\SQLEXPRESS; Initial Catalog = SPMEDICAL_R; user id = sa; pwd = Senai@132; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__Clinica__C73A60558021D41E");

                entity.ToTable("Clinica");

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cnpj");

                entity.Property(e => e.IdEndereco).HasColumnName("idEndereco");

                entity.Property(e => e.NomeFantasia)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeFantasia");

                entity.Property(e => e.RazaoSocial)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("razaoSocial");

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Clinicas)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK__Clinica__idEnder__267ABA7A");
            });

            modelBuilder.Entity<Consultum>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__Consulta__CA9C61F5F157212E");

                entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");

                entity.Property(e => e.DataConsulta)
                    .HasColumnType("datetime")
                    .HasColumnName("dataConsulta");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__Consulta__idMedi__3A81B327");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK__Consulta__idPaci__3C69FB99");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__Consulta__idSitu__3B75D760");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco)
                    .HasName("PK__Endereco__E45B8B27D6A375F8");

                entity.ToTable("Endereco");

                entity.Property(e => e.IdEndereco).HasColumnName("idEndereco");

                entity.Property(e => e.Cep)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cep");

                entity.Property(e => e.Cidade)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cidade");

                entity.Property(e => e.Estado)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Rua)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("rua");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidade)
                    .HasName("PK__Especial__409698056A2A2A8B");

                entity.ToTable("Especialidade");

                entity.Property(e => e.IdEspecialidade).HasColumnName("idEspecialidade");

                entity.Property(e => e.TituloEspecialidade)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tituloEspecialidade");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__Medico__4E03DEBA3FDF4A40");

                entity.ToTable("Medico");

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.Crm)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("crm");

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.IdEspecialidade).HasColumnName("idEspecialidade");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomeMed)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeMed");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__Medico__idClinic__300424B4");

                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .HasConstraintName("FK__Medico__idEspeci__30F848ED");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Medico__idUsuari__31EC6D26");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__Paciente__F48A08F23FA5D397");

                entity.ToTable("Paciente");

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("cpf");

                entity.Property(e => e.DataNasc)
                    .HasColumnType("datetime")
                    .HasColumnName("dataNasc");

                entity.Property(e => e.IdEndereco).HasColumnName("idEndereco");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomePaciente)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomePaciente");

                entity.Property(e => e.Rg)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("rg");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("telefone");

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK__Paciente__idEnde__34C8D9D1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Paciente__idUsua__35BCFE0A");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__Situacao__12AFD19705BF31D8");

                entity.ToTable("Situacao");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.Situacao1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("situacao");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__03006BFF92DE749A");

                entity.ToTable("TipoUsuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.TituloTipoUsuario)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tituloTipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A64F03D387");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeUsuario)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.Senha)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__idTipoU__2D27B809");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
