using MediatR;
using Proyecto1.Application.DTOs;

namespace Proyecto1.Application.Features.Libros.Queries;

public record SearchLibrosQuery(string? Titulo, int? Anio, string? AutorNombre) : IRequest<IEnumerable<LibroDto>>;
