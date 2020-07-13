using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace Infra.Mappings
{
    public class ConvidadoMapping : IEntityTypeConfiguration<Convidado>
    {
        public void Configure(EntityTypeBuilder<Convidado> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FuncionarioId)
                .HasColumnName("funcionario_id")
                .HasColumnType("uniqueidentifier");

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

            builder.ToTable("convidados");
        }
    }
}
