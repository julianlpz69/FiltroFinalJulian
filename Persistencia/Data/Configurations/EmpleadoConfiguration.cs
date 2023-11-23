using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> entity){

            entity.HasKey(e => e.CodigoEmpleado).HasName("PRIMARY");

            entity.ToTable("empleado");

            entity.HasIndex(e => e.CodigoJefe, "codigo_jefe");

            entity.HasIndex(e => e.CodigoOficina, "codigo_oficina");

            entity.Property(e => e.CodigoEmpleado)
                .ValueGeneratedNever()
                .HasColumnName("codigo_empleado");
            entity.Property(e => e.Apellido1)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("apellido1");
            entity.Property(e => e.Apellido2)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("apellido2");
            entity.Property(e => e.CodigoJefe).HasColumnName("codigo_jefe");
            entity.Property(e => e.CodigoOficina)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("codigo_oficina");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Extension)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("extension");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Puesto)
                .HasMaxLength(50)
                .HasColumnName("puesto");

            entity.HasOne(d => d.CodigoJefeNavigation).WithMany(p => p.InverseCodigoJefeNavigation)
                .HasForeignKey(d => d.CodigoJefe)
                .HasConstraintName("empleado_ibfk_2");

            entity.HasOne(d => d.CodigoOficinaNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.CodigoOficina)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empleado_ibfk_1");
   
        }
    }
}