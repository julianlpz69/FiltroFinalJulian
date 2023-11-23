using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistencia.Data;

namespace Application.Repository;
    public class ClienteRepository : GenericRepository<Cliente>, ICliente
    {
        private readonly JardineriaContext _context;

        public ClienteRepository(JardineriaContext context):base(context)
        {
            _context = context;
        }

        // Devuelve un listo de clientes indicando el nombre del cliente y cuantos pedidos ha realizado. Tenga
        // Tenga en cuenta que puede existir cliente que no han realizado ningun pedido



            public async Task<object> ClientesEdadosYPedidos()
            {
                var Clientes = await _context.Clientes
                    .Select(cliente => new
                    {
                        NombreCliente = cliente.NombreCliente,
                        CantidadPedidos = cliente.Pedidos.Any() ? cliente.Pedidos.Count : 0
                    })
                    .OrderByDescending(u => u.CantidadPedidos)
                    .ToListAsync();

                return Clientes;
            }

            // Devuelve el nombre de los clientes que han hecho pagos y el nombre de sus represententas junto con la ciudad de la oficina a la que pertenece el representante


            public async Task<object> ClienteConPagosYReprensentante()
            {
                var Clientes = await _context.Clientes
                .Where(u => u.Pedidos.Any())
                    .Select(cliente => new
                    {
                        NombreCliente = cliente.NombreCliente,
                        NombreRepresentante = cliente.CodigoEmpleadoRepVentasNavigation.Nombre,
                        CiudadOficina = cliente.CodigoEmpleadoRepVentasNavigation.CodigoOficinaNavigation.Ciudad,
                        
                    })
                    .ToListAsync();

                return Clientes;
            }

            //Devuelve un listado que muestre solamente los clientes que nos han realizado ningun pago


            public async Task<IEnumerable<Cliente>> ClientesSinPagos()
            {
                var Clientes = await _context.Clientes
                    .Where(u => u.Pagos.Count == 0)
                    .ToListAsync();

                return Clientes;
            }


            //Devuelve el listado de clientes donde aparezca el nombre del cliente, el nombre y primer apellido de su representante de ventas y la ciudad de su oficna



            public async Task<object> ClientesYReprensentante()
            {
                var Clientes = await _context.Clientes
                    .Select(cliente => new
                    {
                        NombreCliente = cliente.NombreCliente,
                        NombreRepresentante = cliente.CodigoEmpleadoRepVentasNavigation.Nombre,
                        ApellidoRepresentante = cliente.CodigoEmpleadoRepVentasNavigation.Apellido1,
                        CiudadOficina = cliente.CodigoEmpleadoRepVentasNavigation.CodigoOficinaNavigation.Ciudad,
                        
                    })
                    .ToListAsync();

                return Clientes;
            }



            //Devuelve el listado de clientes, el nombre y primer apellido de su representante de ventas y el numero
            // de telefono de la oficina del representante de ventas de aquellos cloentes que no hayan realizado ningun pago


            public async Task<object> ClientesSinPagosYSusReprensentante()
            {
                var Clientes = await _context.Clientes
                .Where( u => u.Pagos.Count() == 0)
                    .Select(cliente => new
                    {
                        NombreCliente = cliente.NombreCliente,
                        NombreRepresentante = cliente.CodigoEmpleadoRepVentasNavigation.Nombre,
                        ApellidoRepresentante = cliente.CodigoEmpleadoRepVentasNavigation.Apellido1,
                        TelefonoOficina = cliente.CodigoEmpleadoRepVentasNavigation.CodigoOficinaNavigation.Telefono,
                        
                    })
                    .ToListAsync();

                return Clientes;
            }
    }