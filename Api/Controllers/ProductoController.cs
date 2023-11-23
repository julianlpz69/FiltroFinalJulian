using Api.Dtos;
using Aplicacion.UnitOfWork;
using AutoMapper;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> Get()
        {
            var Producto = await _unitOfWork.Productos.GetAllAsync();
            return _mapper.Map<List<ProductoDto>>(Producto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductoDto>> Get(int id)
        {
            var Producto = await _unitOfWork.Productos.GetByIdAsync(id);
            return _mapper.Map<ProductoDto>(Producto);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Producto>> Post(ProductoDto ProductoDto)
        {
            var Producto = _mapper.Map<Producto>(ProductoDto);
            _unitOfWork.Productos.Add(Producto);
            await _unitOfWork.SaveAsync();

            if (Producto == null)
            {
                return BadRequest();
            }

            Producto.CodigoProducto = Producto.CodigoProducto;
            return CreatedAtAction(nameof(Post), new { id = Producto.CodigoProducto }, Producto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductoDto>> Put(int id, [FromBody]ProductoDto ProductoDto)
        {
            if (ProductoDto == null)
            {
                return NotFound();
            }

            var Producto = _mapper.Map<Producto>(ProductoDto);
            _unitOfWork.Productos.Update(Producto);
            await _unitOfWork.SaveAsync();
            return ProductoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductoDto>> Delete(int id)
        {
            var Producto = await _unitOfWork.Productos.GetByIdAsync(id);

            if (Producto == null)
            {
                return NotFound();
            }

            _unitOfWork.Productos.Remove(Producto);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }



        [HttpGet("SinPedidos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<object>> ProductoSinPedidos()
        {
            var Producto = await _unitOfWork.Productos.ProductoSinPedidos();
            return Ok(Producto);
        }
    }
}