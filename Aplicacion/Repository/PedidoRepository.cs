using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistencia.Data;

namespace Application.Repository;
    public class PedidoRepository : GenericRepository<Pedido>, IPedido
    {
        private readonly JardineriaContext _context;

        public PedidoRepository(JardineriaContext context):base(context)
        {
            _context = context;
        }


        //Cuantos pedidos hay en cada estado ordena el resultado de forma descendente por el numero de pedidos


         public async Task<object> PedidosXEstados()
            {
                var Pagos = await _context.Pedidos
                    .Select(u => new 
                    {
                         NombreEstafo = u.Estado,
                         Pedidos = _context.Pedidos.Where(p => p.Estado == u.Estado).Count()
                    })
                    .Distinct()
                    .OrderByDescending(u =>u.Pedidos)

                    .ToListAsync();

                return Pagos;
            }
        
    }