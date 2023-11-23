using Dominio.Entities;
using Dominio.Interfaces;
using Persistence.Data;
using Persistencia.Data;

namespace Application.Repository;
    public class OficinaRepository : GenericRepository<Oficina>, IOficina
    {
        private readonly JardineriaContext _context;

        public OficinaRepository(JardineriaContext context):base(context)
        {
            _context = context;
        }
    }