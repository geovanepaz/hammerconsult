using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace Infra.Mappings
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnName("nome")
                .HasColumnType("varchar(255)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasColumnType("varchar(255)");

            builder.Property(c => c.Setor)
                .IsRequired()
                .HasColumnName("setor")
                .HasColumnType("varchar(255)");

            builder.Property(c => c.Cargo)
              .IsRequired()
              .HasColumnName("cargo")
              .HasColumnType("varchar(255)");

            builder.ToTable("funcionarios");
        }
    }
}
