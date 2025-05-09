using MediatR;
using Proyecto1.Application.DTOs;

namespace Proyecto1.Application.Features.Libros.Queries;

public record GetAllLibrosQuery : IRequest<IEnumerable<LibroDto>>;
