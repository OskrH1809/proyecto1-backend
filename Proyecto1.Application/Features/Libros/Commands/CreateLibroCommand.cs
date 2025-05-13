using MediatR;
using Proyecto1.Application.DTOs;

namespace Proyecto1.Application.Features.Libros.Commands;

public record CreateLibroCommand(LibroDto Libro) : IRequest<LibroDto>;
