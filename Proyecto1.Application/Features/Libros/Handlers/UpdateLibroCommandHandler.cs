using AutoMapper;
using MediatR;
using Proyecto1.Application.Features.Libros.Commands;
using Proyecto1.Domain.Interfaces;

namespace Proyecto1.Application.Features.Libros.Handlers;

public class UpdateLibroCommandHandler : IRequestHandler<UpdateLibroCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateLibroCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLibroCommand request, CancellationToken cancellationToken)
    {
        var existing = await _unitOfWork.Libros.GetByIdAsync(request.Id);
        if (existing == null)
            throw new KeyNotFoundException($"Libro with Id {request.Id} not found");

        _mapper.Map(request.Libro, existing);

        _unitOfWork.Libros.Update(existing);
        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}
