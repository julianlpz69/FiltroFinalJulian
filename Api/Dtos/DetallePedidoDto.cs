using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class DetallePedidoDto
    {
        public int CodigoPedido { get; set; }

        public string CodigoProducto { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnidad { get; set; }

        public short NumeroLinea { get; set; }
    }
}