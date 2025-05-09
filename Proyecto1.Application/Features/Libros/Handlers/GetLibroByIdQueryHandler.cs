using AutoMapper;
using MediatR;
using Proyecto1.Application.DTOs;
using Proyecto1.Application.Features.Libros.Queries;
using Proyecto1.Domain.Interfaces;

namespace Proyecto1.Application.Features.Libros.Handlers;

public class GetLibroByIdQueryHandler : IRequestHandler<GetLibroByIdQuery, LibroDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetLibroByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<LibroDto> Handle(GetLibroByIdQuery request, CancellationToken cancellationToken)
    {
        var libro = await _unitOfWork.Libros.GetByIdAsync(request.Id);
        return _mapper.Map<LibroDto>(libro);
    }
}
