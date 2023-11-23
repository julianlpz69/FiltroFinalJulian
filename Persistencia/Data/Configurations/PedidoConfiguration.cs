using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> entity){

            entity.HasKey(e => e.CodigoPedido).HasName("PRIMARY");

            entity.ToTable("pedido");

            entity.HasIndex(e => e.CodigoCliente, "codigo_cliente");

            entity.Property(e => e.CodigoPedido)
                .ValueGeneratedNever()
                .HasColumnName("codigo_pedido");
            entity.Property(e => e.CodigoCliente).HasColumnName("codigo_cliente");
            entity.Property(e => e.Comentarios)
                .HasColumnType("text")
                .HasColumnName("comentarios");
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("estado");
            entity.Property(e => e.FechaEntrega).HasColumnName("fecha_entrega");
            entity.Property(e => e.FechaEsperada).HasColumnName("fecha_esperada");
            entity.Property(e => e.FechaPedido).HasColumnName("fecha_pedido");

            entity.HasOne(d => d.CodigoClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.CodigoCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pedido_ibfk_1");

        }
    }
}