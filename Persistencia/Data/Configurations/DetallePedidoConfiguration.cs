using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DetallePedidoConfiguration : IEntityTypeConfiguration<DetallePedido>
    {
        public void Configure(EntityTypeBuilder<DetallePedido> entity){
            
             entity.HasKey(e => new { e.CodigoPedido, e.CodigoProducto })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("detalle_pedido");

            entity.HasIndex(e => e.CodigoProducto, "codigo_producto");

            entity.Property(e => e.CodigoPedido).HasColumnName("codigo_pedido");
            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(15)
                .HasColumnName("codigo_producto");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.NumeroLinea).HasColumnName("numero_linea");
            entity.Property(e => e.PrecioUnidad)
                .HasPrecision(15, 2)
                .HasColumnName("precio_unidad");

            entity.HasOne(d => d.CodigoPedidoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.CodigoPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalle_pedido_ibfk_1");

            entity.HasOne(d => d.CodigoProductoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.CodigoProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalle_pedido_ibfk_2");
        }
    }
}