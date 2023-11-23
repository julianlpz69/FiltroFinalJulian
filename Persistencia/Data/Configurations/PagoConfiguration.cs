using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PagoConfiguration : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> entity){



            entity.HasKey(e => new { e.CodigoCliente, e.IdTransaccion })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("pago");

            entity.Property(e => e.CodigoCliente).HasColumnName("codigo_cliente");
            entity.Property(e => e.IdTransaccion)
                .HasMaxLength(50)
                .HasColumnName("id_transaccion");
            entity.Property(e => e.FechaPago).HasColumnName("fecha_pago");
            entity.Property(e => e.FormaPago)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnName("forma_pago");
            entity.Property(e => e.Total)
                .HasPrecision(15, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.CodigoClienteNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.CodigoCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pago_ibfk_1");

        }
    }
}