using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class GamaProductoConfiguration : IEntityTypeConfiguration<GamaProducto>
    {
        public void Configure(EntityTypeBuilder<GamaProducto> entity){
            
       
            entity.HasKey(e => e.Gama).HasName("PRIMARY");

            entity.ToTable("gama_producto");

            entity.Property(e => e.Gama)
                .HasMaxLength(50)
                .HasColumnName("gama");
            entity.Property(e => e.DescripcionHtml)
                .HasColumnType("text")
                .HasColumnName("descripcion_html");
            entity.Property(e => e.DescripcionTexto)
                .HasColumnType("text")
                .HasColumnName("descripcion_texto");
            entity.Property(e => e.Imagen)
                .HasMaxLength(256)
                .HasColumnName("imagen");
   
        }
    }
}