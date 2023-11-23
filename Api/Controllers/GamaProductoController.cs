using Api.Dtos;
using Aplicacion.UnitOfWork;
using AutoMapper;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GamaProductoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GamaProductoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<GamaProductoDto>>> Get()
        {
            var GamaProducto = await _unitOfWork.GamasProducto.GetAllAsync();
            return _mapper.Map<List<GamaProductoDto>>(GamaProducto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GamaProductoDto>> Get(int id)
        {
            var GamaProducto = await _unitOfWork.GamasProducto.GetByIdAsync(id);
            return _mapper.Map<GamaProductoDto>(GamaProducto);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GamaProducto>> Post(GamaProductoDto GamaProductoDto)
        {
            var GamaProducto = _mapper.Map<GamaProducto>(GamaProductoDto);
            _unitOfWork.GamasProducto.Add(GamaProducto);
            await _unitOfWork.SaveAsync();

            if (GamaProducto == null)
            {
                return BadRequest();
            }

            GamaProducto.Gama = GamaProducto.Gama;
            return CreatedAtAction(nameof(Post), new { id = GamaProducto.Gama }, GamaProducto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GamaProductoDto>> Put(int id, [FromBody]GamaProductoDto GamaProductoDto)
        {
            if (GamaProductoDto == null)
            {
                return NotFound();
            }

            var GamaProducto = _mapper.Map<GamaProducto>(GamaProductoDto);
            _unitOfWork.GamasProducto.Update(GamaProducto);
            await _unitOfWork.SaveAsync();
            return GamaProductoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GamaProductoDto>> Delete(int id)
        {
            var GamaProducto = await _unitOfWork.GamasProducto.GetByIdAsync(id);

            if (GamaProducto == null)
            {
                return NotFound();
            }

            _unitOfWork.GamasProducto.Remove(GamaProducto);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}