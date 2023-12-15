using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CategoriaProductoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriaProductoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<List<CategoriaProductoDto>>> Get()
        {
            var r = await _unitOfWork.CategoriaProductos.GetAllAsync();
            var CategoriaProductoListDto = _mapper.Map<List<CategoriaProductoDto>>(r);
            return CategoriaProductoListDto;
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<CategoriaProducto>> Post(
            CategoriaProductoDto CategoriaProductoDto
        )
        {
            var CategoriaProducto = _mapper.Map<CategoriaProducto>(CategoriaProductoDto);
            _unitOfWork.CategoriaProductos.Add(CategoriaProducto);
            await _unitOfWork.SaveAsync();
            CategoriaProductoDto.Id = CategoriaProducto.Id;
            return CreatedAtAction(
                nameof(Post),
                new { id = CategoriaProductoDto.Id },
                CategoriaProductoDto
            );
        }

        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<CategoriaProductoDto>> Put(
            int id,
            [FromBody] CategoriaProductoDto CategoriaProductoDto
        )
        {
            if (CategoriaProductoDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var CategoriaProducto = _mapper.Map<CategoriaProducto>(CategoriaProductoDto);
            _unitOfWork.CategoriaProductos.Update(CategoriaProducto);
            await _unitOfWork.SaveAsync();
            return CategoriaProductoDto;
        }

        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var CategoriaProducto = await _unitOfWork.CategoriaProductos.GetByIdAsync(id);
            _unitOfWork.CategoriaProductos.Remove(CategoriaProducto);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
