using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IPago : IGenericRepository<Pago>
    {
        Task<IEnumerable<Pago>> Pagos2008Paypal();
        Task<object> FormasPago();
    }
}