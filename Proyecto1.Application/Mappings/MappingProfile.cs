using AutoMapper;
using Proyecto1.Domain.Entities;
using Proyecto1.Application.DTOs;

namespace Proyecto1.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Autor, AutorDto>().ReverseMap();
        CreateMap<Libro, LibroDto>().ReverseMap();
    }
}
