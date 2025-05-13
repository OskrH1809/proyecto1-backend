using MediatR;

namespace Proyecto1.Application.Features.Libros.Commands;

public record DeleteLibroCommand(int Id) : IRequest<Unit>;
