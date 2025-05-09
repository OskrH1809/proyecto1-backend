using AutoMapper;
using MediatR;
using Proyecto1.Application.DTOs;
using Proyecto1.Application.Features.Autores.Queries;
using Proyecto1.Domain.Interfaces;

namespace Proyecto1.Application.Features.Autores.Handlers;

public class GetAllAutoresQueryHandler : IRequestHandler<GetAllAutoresQuery, IEnumerable<AutorDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllAutoresQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AutorDto>> Handle(GetAllAutoresQuery request, CancellationToken cancellationToken)
    {
        var autores = await _unitOfWork.Autores.GetAllAsync();
        return _mapper.Map<IEnumerable<AutorDto>>(autores);
    }
}
    