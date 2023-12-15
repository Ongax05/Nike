using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile (){
            CreateMap<CategoriaProducto,CategoriaProductoDto>().ReverseMap();
            CreateMap<Producto,ProductoDto>().ReverseMap();
            CreateMap<Orden,OrdenDto>().ReverseMap();
            CreateMap<OrdenProducto,OrdenProductoDto>().ReverseMap();
        }
    }
}