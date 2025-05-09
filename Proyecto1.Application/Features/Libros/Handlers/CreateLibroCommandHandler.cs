using AutoMapper;
using MediatR;
using Proyecto1.Application.DTOs;
using Proyecto1.Application.Features.Libros.Commands;
using Proyecto1.Domain.Entities;
using Proyecto1.Domain.Interfaces;

namespace Proyecto1.Application.Features.Libros.Handlers;

public class CreateLibroCommandHandler : IRequestHandler<CreateLibroCommand, LibroDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateLibroCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<LibroDto> Handle(CreateLibroCommand request, CancellationToken cancellationToken)
    {
        var libroEntity = _mapper.Map<Libro>(request.Libro);
        await _unitOfWork.Libros.AddAsync(libroEntity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<LibroDto>(libroEntity);
    }
}
