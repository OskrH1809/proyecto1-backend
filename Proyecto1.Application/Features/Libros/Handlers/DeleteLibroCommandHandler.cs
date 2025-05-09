using MediatR;
using Proyecto1.Application.Features.Libros.Commands;
using Proyecto1.Domain.Interfaces;

namespace Proyecto1.Application.Features.Libros.Handlers;

public class DeleteLibroCommandHandler : IRequestHandler<DeleteLibroCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLibroCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteLibroCommand request, CancellationToken cancellationToken)
    {
        var libro = await _unitOfWork.Libros.GetByIdAsync(request.Id);
        if (libro == null)
            throw new KeyNotFoundException($"Libro with Id {request.Id} not found");

        _unitOfWork.Libros.Remove(libro);
        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}
