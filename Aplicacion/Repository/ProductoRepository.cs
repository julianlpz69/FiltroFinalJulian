using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistencia.Data;

namespace Application.Repository;
    public class ProductoRepository : GenericRepository<Producto>, IProducto
    {
        private readonly JardineriaContext _context;

        public ProductoRepository(JardineriaContext context):base(context)
        {
            _context = context;
        }


        // Devuelve un listado de los productos que nunca han aparecido en un pedido. El resultado debe mostrar el nombre, la descripcion y la imagen del producot



        public async Task<object> ProductoSinPedidos()
            {
                var Productos = await _context.Productos
                .Where(u => u.DetallePedidos.Count() == 0)
                    .Select(Producto => new
                    {
                        Nombreproducto = Producto.Nombre,
                        DescripcionProducto = Producto.Descripcion,
                        ImagenProducto = "No Tiene",
                        
                    })
                    .ToListAsync();

                return Productos;
            }
    }