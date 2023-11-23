

using Aplicacion.UnitOfWork;
using Application.Repository;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Application.UnitOfWork;

    public class UnitOfWork : IUnitOfWork
    {

        private readonly JardineriaContext _context; 
        

       private ICliente _Clientes ;
       private IDetallePedido _DetallesPedidos ;
       private IEmpleado _Empleados ;

       private IGamaProducto _GamaProdcutos;
       private IOficina _Oficinas ;
       private IPago _Pagos ;

       private IPedido _Pedidos ;
       private IProducto _Productos ;

        public UnitOfWork(JardineriaContext context){
            _context = context;
        }




        public ICliente Clientes
        {
            get{
                if (_Clientes == null)
                {
                    _Clientes = new ClienteRepository(_context);
                }
                return _Clientes;
            }
        }


        public IDetallePedido DetallesPedidos
        {
            get{
                if (_DetallesPedidos == null)
                {
                    _DetallesPedidos = new DetallePedidoRepository(_context);
                }
                return _DetallesPedidos;
            }
        }


        public IEmpleado Empleados
        {
            get{
                if (_Empleados == null)
                {
                    _Empleados = new EmpleadoRepository(_context);
                }
                return _Empleados;
            }
        }



        public IGamaProducto GamasProducto
        {
            get{
                if (_GamaProdcutos == null)
                {
                    _GamaProdcutos = new GamaProductoRepository(_context);
                }
                return _GamaProdcutos;
            }
        }


        
        public IOficina Oficinas
        {
            get{
                if (_Oficinas == null)
                {
                    _Oficinas = new OficinaRepository(_context);
                }
                return _Oficinas;
            }
        }



        public IPago Pagos
        {
            get{
                if (_Pagos == null)
                {
                    _Pagos = new PagoRepository(_context);
                }
                return _Pagos;
            }
        }



        public IPedido Pedidos
        {
            get{
                if (_Pedidos == null)
                {
                    _Pedidos = new PedidoRepository(_context);
                }
                return _Pedidos;
            }
        }


        public IProducto Productos
        {
            get{
                if (_Productos == null)
                {
                    _Productos = new ProductoRepository(_context);
                }
                return _Productos;
            }
        }


        

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }