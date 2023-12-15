using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<List<ProductoDto>>> Get()
        {
            var r = await _unitOfWork.Productos.GetAllAsync();
            var ProductoListDto = _mapper.Map<List<ProductoDto>>(r);
            return ProductoListDto;
        }

        [HttpGet("Abrigos")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<List<ProductoDto>>> Get_Abrigos()
        {
            var r = await _unitOfWork.Productos.GetAbrigos();
            var ProductoListDto = _mapper.Map<List<ProductoDto>>(r);
            return ProductoListDto;
        }

        [HttpGet("Camisetas")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<List<ProductoDto>>> Get_Camisetas()
        {
            var r = await _unitOfWork.Productos.GetCamisetas();
            var ProductoListDto = _mapper.Map<List<ProductoDto>>(r);
            return ProductoListDto;
        }

        [HttpGet("Pantalones")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<List<ProductoDto>>> Get_Pantalones()
        {
            var r = await _unitOfWork.Productos.GetPantalones();
            var ProductoListDto = _mapper.Map<List<ProductoDto>>(r);
            return ProductoListDto;
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Producto>> Post(ProductoDto ProductoDto)
        {
            var Producto = _mapper.Map<Producto>(ProductoDto);
            _unitOfWork.Productos.Add(Producto);
            await _unitOfWork.SaveAsync();
            ProductoDto.Id = Producto.Id;
            return CreatedAtAction(nameof(Post), new { id = ProductoDto.Id }, ProductoDto);
        }

        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<ProductoDto>> Put(int id, [FromBody] ProductoDto ProductoDto)
        {
            if (ProductoDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Producto = _mapper.Map<Producto>(ProductoDto);
            _unitOfWork.Productos.Update(Producto);
            await _unitOfWork.SaveAsync();
            return ProductoDto;
        }

        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Producto = await _unitOfWork.Productos.GetByIdAsync(id);
            _unitOfWork.Productos.Remove(Producto);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
