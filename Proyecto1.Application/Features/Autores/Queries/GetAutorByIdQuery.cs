using MediatR;
using Proyecto1.Application.DTOs;

namespace Proyecto1.Application.Features.Autores.Queries;

public record GetAutorByIdQuery(int Id) : IRequest<AutorDto>;
