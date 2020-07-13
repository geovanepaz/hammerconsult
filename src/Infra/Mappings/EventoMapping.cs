using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace Infra.Mappings
{
    public class EventoMapping : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnName("descricao")
                .HasColumnType("varchar(500)");

            builder.Property(c => c.Data)
                .IsRequired()
                .HasColumnName("data")
                .HasColumnType("datetime2");

            builder.Property(c => c.CustoBebida)
                .IsRequired()
                .HasColumnName("custo_bebida")
                .HasColumnType("decimal");

            builder.Property(c => c.CustoComida)
                .IsRequired()
                .HasColumnName("custo_comida")
                .HasColumnType("decimal");

            builder.ToTable("eventos");
        }
    }
}
