using AutoMapper;
using MediatR;
using Proyecto1.Application.Features.Autores.Commands;
using Proyecto1.Domain.Interfaces;

namespace Proyecto1.Application.Features.Autores.Handlers;

public class UpdateAutorCommandHandler : IRequestHandler<UpdateAutorCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateAutorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateAutorCommand request, CancellationToken cancellationToken)
    {
        var existing = await _unitOfWork.Autores.GetByIdAsync(request.Id);
        if (existing == null)
            throw new KeyNotFoundException($"Autor with Id {request.Id} not found");

        _mapper.Map(request.Autor, existing);

        _unitOfWork.Autores.Update(existing);
        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}
