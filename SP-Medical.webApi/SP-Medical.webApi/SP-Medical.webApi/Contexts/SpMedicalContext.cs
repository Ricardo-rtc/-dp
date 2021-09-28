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

        public virtual DbSet<Aluguei> Alugueis { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Modelo> Modelos { get; set; }
        public virtual DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-C8POL51\\SQLEXPRESS; initial catalog=M_Rental; user Id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Aluguei>(entity =>
            {
                entity.HasKey(e => e.IdAluguel)
                    .HasName("PK__Alugueis__E38F97EDC7F6224B");

                entity.Property(e => e.DataFim).HasColumnType("date");

                entity.Property(e => e.DataInicio).HasColumnType("date");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Alugueis)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Alugueis__IdClie__35BCFE0A");

                entity.HasOne(d => d.IdVeiculoNavigation)
                    .WithMany(p => p.Alugueis)
                    .HasForeignKey(d => d.IdVeiculo)
                    .HasConstraintName("FK__Alugueis__IdVeic__36B12243");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__D594664299B874A6");

                entity.HasIndex(e => e.Cpf, "UQ__Clientes__C1F8973148B4E245")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Sobrenome)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__Empresas__5EF4033E36F94F32");

                entity.HasIndex(e => e.NomeEmpresa, "UQ__Empresas__7D8FE3B21D764668")
                    .IsUnique();

                entity.Property(e => e.NomeEmpresa)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__Marcas__4076A887B6DEA987");

                entity.HasIndex(e => e.NomeMarca, "UQ__Marcas__7D8FE3B2439D1563")
                    .IsUnique();

                entity.Property(e => e.NomeMarca)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasKey(e => e.IdModelo)
                    .HasName("PK__Modelos__CC30D30C3FF02CA8");

                entity.HasIndex(e => e.Descricao, "UQ__Modelos__008BA9EF54DFF7B5")
                    .IsUnique();

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Modelos)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK__Modelos__IdMarca__2B3F6F97");
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.HasKey(e => e.IdVeiculo)
                    .HasName("PK__Veiculos__CAC4F346640ACD69");

                entity.HasIndex(e => e.Placa, "UQ__Veiculos__8310F99D57AF2128")
                    .IsUnique();

                entity.Property(e => e.Placa)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Veiculos)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__Veiculos__IdEmpr__300424B4");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Veiculos)
                    .HasForeignKey(d => d.IdModelo)
                    .HasConstraintName("FK__Veiculos__IdMode__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
