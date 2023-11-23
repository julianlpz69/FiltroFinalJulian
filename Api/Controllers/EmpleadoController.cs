using Api.Dtos;
using Aplicacion.UnitOfWork;
using AutoMapper;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmpleadoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get()
        {
            var Empleado = await _unitOfWork.Empleados.GetAllAsync();
            return _mapper.Map<List<EmpleadoDto>>(Empleado);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmpleadoDto>> Get(int id)
        {
            var Empleado = await _unitOfWork.Empleados.GetByIdAsync(id);
            return _mapper.Map<EmpleadoDto>(Empleado);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Empleado>> Post(EmpleadoDto EmpleadoDto)
        {
            var Empleado = _mapper.Map<Empleado>(EmpleadoDto);
            _unitOfWork.Empleados.Add(Empleado);
            await _unitOfWork.SaveAsync();

            if (Empleado == null)
            {
                return BadRequest();
            }

            Empleado.CodigoEmpleado = Empleado.CodigoEmpleado;
            return CreatedAtAction(nameof(Post), new { id = Empleado.CodigoEmpleado }, Empleado);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmpleadoDto>> Put(int id, [FromBody]EmpleadoDto EmpleadoDto)
        {
            if (EmpleadoDto == null)
            {
                return NotFound();
            }

            var Empleado = _mapper.Map<Empleado>(EmpleadoDto);
            _unitOfWork.Empleados.Update(Empleado);
            await _unitOfWork.SaveAsync();
            return EmpleadoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmpleadoDto>> Delete(int id)
        {
            var Empleado = await _unitOfWork.Empleados.GetByIdAsync(id);

            if (Empleado == null)
            {
                return NotFound();
            }

            _unitOfWork.Empleados.Remove(Empleado);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }




        [HttpGet("EmpleadosYGefes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<object>> EmpleadosYGefes()
        {
            var Empleado = await _unitOfWork.Empleados.EmpleadosYGefes();
            return Ok(Empleado);
        }
    }
}