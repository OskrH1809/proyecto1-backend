using MediatR;
using Proyecto1.Application.Features.Autores.Commands;
using Proyecto1.Domain.Interfaces;

namespace Proyecto1.Application.Features.Autores.Handlers;

public class DeleteAutorCommandHandler : IRequestHandler<DeleteAutorCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAutorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteAutorCommand request, CancellationToken cancellationToken)
    {
        var autor = await _unitOfWork.Autores.GetByIdAsync(request.Id);
        if (autor == null)
            throw new KeyNotFoundException($"Autor with Id {request.Id} not found");

        _unitOfWork.Autores.Remove(autor);
        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}
