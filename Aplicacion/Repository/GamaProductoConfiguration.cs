using Dominio.Entities;
using Dominio.Interfaces;
using Persistence.Data;
using Persistencia.Data;

namespace Application.Repository;
    public class GamaProductoRepository : GenericRepository<GamaProducto>, IGamaProducto
    {
        private readonly JardineriaContext _context;

        public GamaProductoRepository(JardineriaContext context):base(context)
        {
            _context = context;
        }
    }