using AutoMapper;
using MediatR;
using Proyecto1.Application.DTOs;
using Proyecto1.Application.Features.Libros.Queries;
using Proyecto1.Domain.Interfaces;

namespace Proyecto1.Application.Features.Libros.Handlers;

public class SearchLibrosQueryHandler : IRequestHandler<SearchLibrosQuery, IEnumerable<LibroDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SearchLibrosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LibroDto>> Handle(SearchLibrosQuery request, CancellationToken cancellationToken)
    {
        var libros = await _unitOfWork.Libros.GetAllWithAutoresAsync();

        if (!string.IsNullOrWhiteSpace(request.Titulo))
            libros = libros.Where(l => l.Titulo.Contains(request.Titulo, StringComparison.OrdinalIgnoreCase));

        if (request.Anio.HasValue)
            libros = libros.Where(l => l.Anio == request.Anio);

        if (!string.IsNullOrWhiteSpace(request.AutorNombre))
            libros = libros.Where(l => l.Autor != null && l.Autor.NombreCompleto.Contains(request.AutorNombre, StringComparison.OrdinalIgnoreCase));

        return _mapper.Map<IEnumerable<LibroDto>>(libros);
    }
}
