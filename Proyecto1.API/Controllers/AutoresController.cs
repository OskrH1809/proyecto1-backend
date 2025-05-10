using Microsoft.AspNetCore.Mvc;
using MediatR;
using Proyecto1.Application.DTOs;
using Proyecto1.Application.Features.Autores.Commands;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var autor = await _mediator.Send(new GetAutorByIdQuery(id));
        if (autor == null)
            return NotFound();
        return Ok(autor);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAutorCommand command)
    {
        var autor = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = autor.Id }, autor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAutorCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteAutorCommand(id));
        return NoContent();
    }
}
