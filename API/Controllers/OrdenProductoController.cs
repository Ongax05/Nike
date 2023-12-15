using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrdenProductoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrdenProductoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<List<OrdenProductoDto>>> Get()
        {
            var r = await _unitOfWork.OrdenProductos.GetAllAsync();
            var OrdenProductoListDto = _mapper.Map<List<OrdenProductoDto>>(r);
            return OrdenProductoListDto;
        }

        private ActionResult<Pager<OrdenProductoDto>> BadRequest(ApiResponse apiResponse)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<OrdenProductoDto>>> Get1_1()
        {
            var registers = await _unitOfWork.OrdenProductos.GetAllAsync();
            var OrdenProductoListDto = _mapper.Map<List<OrdenProductoDto>>(registers);
            return OrdenProductoListDto;
        }
    }
}
