using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace Infra.Mappings
{
    public class ParticipanteEventoMapping : IEntityTypeConfiguration<ParticipanteEvento>
    {
        public void Configure(EntityTypeBuilder<ParticipanteEvento> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
              .HasColumnName("id");

            builder.Property(c => c.EventoId)
                .IsRequired()
                .HasColumnName("evento_id")
                .HasColumnType("uniqueidentifier");

            builder.Property(c => c.FuncionarioId)
                .IsRequired()
                .HasColumnName("funcionario_id")
                .HasColumnType("uniqueidentifier");

            builder.Property(c => c.ConvidadoId)
              .HasColumnName("convidado_id")
              .HasColumnType("uniqueidentifier");

            builder.Property(c => c.ValorComida)
                .HasColumnName("valor_comida")
                .HasColumnType("decimal");

            builder.Property(c => c.ValorBebida)
                .HasColumnName("valor_bebida")
                .HasColumnType("decimal");

            builder.Property(c => c.ConvidadoComBebida)
                .HasColumnName("convidado_bebida_inclusa")
                .HasColumnType("bit");

            builder.Property(c => c.FuncionarioComBebida)
               .HasColumnName("funcionario_bebida_inclusa")
               .HasColumnType("bit");

            builder.ToTable("participantes_evento");
        }
    }
}
