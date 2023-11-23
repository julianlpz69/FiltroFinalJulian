using Api.Dtos;
using Aplicacion.UnitOfWork;
using AutoMapper;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ClienteController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
        {
            var Cliente = await _unitOfWork.Clientes.GetAllAsync();
            return _mapper.Map<List<ClienteDto>>(Cliente);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteDto>> Get(int id)
        {
            var Cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
            return _mapper.Map<ClienteDto>(Cliente);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cliente>> Post(ClienteDto ClienteDto)
        {
            var Cliente = _mapper.Map<Cliente>(ClienteDto);
            _unitOfWork.Clientes.Add(Cliente);
            await _unitOfWork.SaveAsync();

            if (Cliente == null)
            {
                return BadRequest();
            }

            Cliente.CodigoCliente = Cliente.CodigoCliente;
            return CreatedAtAction(nameof(Post), new { id = Cliente.CodigoCliente }, Cliente);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteDto>> Put(int id, [FromBody]ClienteDto ClienteDto)
        {
            if (ClienteDto == null)
            {
                return NotFound();
            }

            var Cliente = _mapper.Map<Cliente>(ClienteDto);
            _unitOfWork.Clientes.Update(Cliente);
            await _unitOfWork.SaveAsync();
            return ClienteDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteDto>> Delete(int id)
        {
            var Cliente = await _unitOfWork.Clientes.GetByIdAsync(id);

            if (Cliente == null)
            {
                return NotFound();
            }

            _unitOfWork.Clientes.Remove(Cliente);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }





        [HttpGet("EdadosYPedidos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> EdadosYPedidos()
        {
            var Cliente = await _unitOfWork.Clientes.ClientesEdadosYPedidos();
            return Ok(Cliente);
        }


        [HttpGet("ConPagosYReprensentante")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> ClienteConPagosYReprensentante()
        {
            var Cliente = await _unitOfWork.Clientes.ClienteConPagosYReprensentante();
            return Ok(Cliente);
        }



        [HttpGet("SinPagos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> ClientesSinPagos()
        {
            var Cliente = await _unitOfWork.Clientes.ClientesSinPagos();
            return _mapper.Map<List<ClienteDto>>(Cliente);
        }




        [HttpGet("YReprensentante")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> ClientesYReprensentante()
        {
            var Cliente = await _unitOfWork.Clientes.ClientesYReprensentante();
            return Ok(Cliente);
        }


        [HttpGet("SinPagosYSusReprensentante")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> ClientesSinPagosYSusReprensentante()
        {
            var Cliente = await _unitOfWork.Clientes.ClientesSinPagosYSusReprensentante();
            return Ok(Cliente);
        }
    }
}