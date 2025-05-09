using AutoMapper;
using MediatR;
using Proyecto1.Application.DTOs;
using Proyecto1.Application.Features.Autores.Queries;
using Proyecto1.Domain.Interfaces;

namespace Proyecto1.Application.Features.Autores.Handlers;

public class GetAutorByIdQueryHandler : IRequestHandler<GetAutorByIdQuery, AutorDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAutorByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AutorDto> Handle(GetAutorByIdQuery request, CancellationToken cancellationToken)
    {
        var autor = await _unitOfWork.Autores.GetByIdAsync(request.Id);
        return _mapper.Map<AutorDto>(autor);
    }
}
