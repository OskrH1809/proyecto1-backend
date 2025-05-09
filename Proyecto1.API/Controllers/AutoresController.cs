using Microsoft.AspNetCore.Mvc;
using MediatR;
using Proyecto1.Application.Features.Autores.Queries;

namespace Proyecto1.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutoresController : ControllerBase
{
    private readonly IMediator _mediator;

    public AutoresController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var autores = await _mediator.Send(new GetAllAutoresQuery());
        return Ok(autores);
    }
}
