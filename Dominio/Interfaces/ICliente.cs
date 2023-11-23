using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface ICliente : IGenericRepository<Cliente>
    {
        Task<object> ClientesEdadosYPedidos();
        Task<object> ClienteConPagosYReprensentante();
        Task<IEnumerable<Cliente>> ClientesSinPagos();
        Task<object> ClientesYReprensentante();
        Task<object> ClientesSinPagosYSusReprensentante();
    }
}