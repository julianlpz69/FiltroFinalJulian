using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistencia.Data;

namespace Application.Repository;
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
    {
        private readonly JardineriaContext _context;

        public EmpleadoRepository(JardineriaContext context):base(context)
        {
            _context = context;
        }


        // Devuelve un listado que muestre el nombre de cada empleado, el nombre de su gefe y el nombre del gefe de su gefe


        public async Task<object> EmpleadosYGefes()
        {
            var Empleados = await _context.Empleados
                .Select(Empleado => new
                {
                    NombreEmpleado = Empleado.Nombre,
                    NombreGefe = Empleado.CodigoJefeNavigation != null ? Empleado.CodigoJefeNavigation.Nombre : "No tiene Gefe",
                    NombreGefeDelGefe = Empleado.CodigoJefeNavigation.CodigoJefeNavigation != null ? Empleado.CodigoJefeNavigation.CodigoJefeNavigation.Nombre : "El Gefe No tiene Gefe",
                    
                })
                .ToListAsync();

            return Empleados;
        }


    }