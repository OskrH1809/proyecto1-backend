using MediatR;
using Proyecto1.Application.DTOs;

namespace Proyecto1.Application.Features.Libros.Queries;

public record SearchLibrosQuery(string? Query) : IRequest<IEnumerable<LibroAutorDto>>;
