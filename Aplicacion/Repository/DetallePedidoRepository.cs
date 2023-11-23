using Dominio.Entities;
using Dominio.Interfaces;
using Persistence.Data;
using Persistencia.Data;

namespace Application.Repository;
    public class DetallePedidoRepository : GenericRepository<DetallePedido>, IDetallePedido
    {
        private readonly JardineriaContext _context;

        public DetallePedidoRepository(JardineriaContext context):base(context)
        {
            _context = context;
        }
    }