using Microsoft.AspNetCore.Mvc;
using MediatR;
using Proyecto1.Application.DTOs;
using Proyecto1.Application.Features.Libros.Commands;
using Proyecto1.Application.Features.Libros.Queries;
using Proyecto1.Application.Features.Autores.Commands;

namespace Proyecto1.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibrosController : ControllerBase
{
    private readonly IMediator _mediator;

    public LibrosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var libros = await _mediator.Send(new GetAllLibrosQuery());
        return Ok(libros);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var libro = await _mediator.Send(new GetLibroByIdQuery(id));
        if (libro == null)
            return NotFound();
        return Ok(libro);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLibroCommand command)
    {
        var libro = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = libro.Id }, libro);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateLibroCommand command)
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
