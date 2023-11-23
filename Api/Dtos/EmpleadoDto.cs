using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class EmpleadoDto
    {
        public int CodigoEmpleado { get; set; }

        public string Nombre { get; set; }

        public string Apellido1 { get; set; }

        public string Apellido2 { get; set; }

        public string Extension { get; set; }

        public string Email { get; set; }

        public string CodigoOficina { get; set; }

        public int? CodigoJefe { get; set; }

        public string Puesto { get; set; }
    }
}