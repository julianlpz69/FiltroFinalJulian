using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistencia.Data;

namespace Application.Repository;
    public class PagoRepository : GenericRepository<Pago>, IPago
    {
        private readonly JardineriaContext _context;

        public PagoRepository(JardineriaContext context):base(context)
        {
            _context = context;
        }


        // Devuelve un listado de todos los pagos que se realizaron en el año 2008 mediante paypal

        public async Task<IEnumerable<Pago>> Pagos2008Paypal()
            {
                var Pagos = await _context.Pagos
                    .Where(U => U.FechaPago.Year == 2008 && U.FormaPago == "PayPal")
                    .OrderByDescending(u => u.Total)
                    .ToListAsync();

                return Pagos;
            }





            // Devuelve un listado de las formas de pago que aparecen en la tabla pago sin repetirse

        public async Task<object> FormasPago()
            {
                var Pagos = await _context.Pagos
                    .Select(u => u.FormaPago)
                    .Distinct()
                    .ToListAsync();

                return Pagos;
            }
    }