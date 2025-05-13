using AutoMapper;
using MediatR;
using Proyecto1.Application.DTOs;
using Proyecto1.Application.Features.Libros.Queries;
using Proyecto1.Domain.Interfaces;

namespace Proyecto1.Application.Features.Libros.Handlers;

public class GetAllLibrosQueryHandler : IRequestHandler<GetAllLibrosQuery, IEnumerable<LibroAutorDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllLibrosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LibroAutorDto>> Handle(GetAllLibrosQuery request, CancellationToken cancellationToken)
    {
        var libros = await _unitOfWork.Libros.GetAllWithAutoresAsync();

        return _mapper.Map<IEnumerable<LibroAutorDto>>(libros);
    }
}
