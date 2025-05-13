using MediatR;

namespace Proyecto1.Application.Features.Autores.Commands;

public record DeleteAutorCommand(int Id) : IRequest<Unit>;
