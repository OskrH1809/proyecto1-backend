using MediatR;
using Proyecto1.Application.DTOs;

namespace Proyecto1.Application.Features.Libros.Commands;

public record UpdateLibroCommand(int Id, LibroDto Libro) : IRequest<Unit>;
