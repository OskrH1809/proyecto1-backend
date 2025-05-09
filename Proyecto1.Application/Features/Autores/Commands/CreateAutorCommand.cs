using MediatR;
using Proyecto1.Application.DTOs;

namespace Proyecto1.Application.Features.Autores.Commands;

public record CreateAutorCommand(AutorDto Autor) : IRequest<AutorDto>;
