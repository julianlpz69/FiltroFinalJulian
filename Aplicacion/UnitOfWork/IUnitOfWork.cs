using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces;

namespace Aplicacion.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
        ICliente Clientes { get; }
        IDetallePedido DetallesPedidos { get; }
        IEmpleado Empleados { get; }
        IGamaProducto GamasProducto {get;}
        IOficina Oficinas { get; }
        IPago Pagos { get; }
        IPedido Pedidos { get; }
        IProducto Productos { get; }

    }
}