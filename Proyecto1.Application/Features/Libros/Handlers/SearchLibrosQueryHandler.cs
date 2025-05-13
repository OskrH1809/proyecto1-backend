using AutoMapper;
using MediatR;
using Proyecto1.Application.DTOs;
using Proyecto1.Application.Features.Libros.Queries;
using Proyecto1.Domain.Interfaces;

public class SearchLibrosQueryHandler : IRequestHandler<SearchLibrosQuery, IEnumerable<LibroAutorDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SearchLibrosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LibroAutorDto>> Handle(SearchLibrosQuery request, CancellationToken cancellationToken)
    {
        var libros = await _unitOfWork.Libros.BuscarPorTextoAsync(request.Query);
        return _mapper.Map<IEnumerable<LibroAutorDto>>(libros);
    }
}
