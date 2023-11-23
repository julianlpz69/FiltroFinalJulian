using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace Api.Profiles
{
    
    public class MappingProfiles : Profile
    {
         public MappingProfiles()
         {
                
            CreateMap<Cliente,ClienteDto>().ReverseMap();

            CreateMap<Empleado,EmpleadoDto>().ReverseMap();

            CreateMap<Producto,ProductoDto>().ReverseMap();

            CreateMap<Pago,PagoDto>().ReverseMap();

            CreateMap<Pedido,PedidoDto>().ReverseMap();

            CreateMap<GamaProducto,GamaProductoDto>().ReverseMap();

            CreateMap<Oficina,OficinaDto>().ReverseMap();

            CreateMap<DetallePedido,DetallePedidoDto>().ReverseMap();
         }
    }
}