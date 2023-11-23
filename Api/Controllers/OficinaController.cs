using Api.Dtos;
using Aplicacion.UnitOfWork;
using AutoMapper;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OficinaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OficinaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OficinaDto>>> Get()
        {
            var Oficina = await _unitOfWork.Oficinas.GetAllAsync();
            return _mapper.Map<List<OficinaDto>>(Oficina);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OficinaDto>> Get(int id)
        {
            var Oficina = await _unitOfWork.Oficinas.GetByIdAsync(id);
            return _mapper.Map<OficinaDto>(Oficina);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Oficina>> Post(OficinaDto OficinaDto)
        {
            var Oficina = _mapper.Map<Oficina>(OficinaDto);
            _unitOfWork.Oficinas.Add(Oficina);
            await _unitOfWork.SaveAsync();

            if (Oficina == null)
            {
                return BadRequest();
            }

            Oficina.CodigoOficina = Oficina.CodigoOficina;
            return CreatedAtAction(nameof(Post), new { id = Oficina.CodigoOficina }, Oficina);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OficinaDto>> Put(int id, [FromBody]OficinaDto OficinaDto)
        {
            if (OficinaDto == null)
            {
                return NotFound();
            }

            var Oficina = _mapper.Map<Oficina>(OficinaDto);
            _unitOfWork.Oficinas.Update(Oficina);
            await _unitOfWork.SaveAsync();
            return OficinaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OficinaDto>> Delete(int id)
        {
            var Oficina = await _unitOfWork.Oficinas.GetByIdAsync(id);

            if (Oficina == null)
            {
                return NotFound();
            }

            _unitOfWork.Oficinas.Remove(Oficina);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}