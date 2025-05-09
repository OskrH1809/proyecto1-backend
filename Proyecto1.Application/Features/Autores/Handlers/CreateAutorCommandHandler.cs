using AutoMapper;
using MediatR;
using Proyecto1.Application.DTOs;
using Proyecto1.Application.Features.Autores.Commands;
using Proyecto1.Domain.Entities;
using Proyecto1.Domain.Interfaces;

namespace Proyecto1.Application.Features.Autores.Handlers;

public class CreateAutorCommandHandler : IRequestHandler<CreateAutorCommand, AutorDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateAutorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AutorDto> Handle(CreateAutorCommand request, CancellationToken cancellationToken)
    {
        var autorEntity = _mapper.Map<Autor>(request.Autor);
        await _unitOfWork.Autores.AddAsync(autorEntity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<AutorDto>(autorEntity);
    }
}
