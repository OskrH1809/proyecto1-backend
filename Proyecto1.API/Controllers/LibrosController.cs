using Microsoft.AspNetCore.Mvc;
using Proyecto1.Domain.Entities;
using Proyecto1.Domain.Interfaces;

namespace Proyecto1.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibrosController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public LibrosController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var libros = await _unitOfWork.Libros.GetAllAsync();
        return Ok(libros);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var libro = await _unitOfWork.Libros.GetByIdAsync(id);
        if (libro == null)
            return NotFound();

        return Ok(libro);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Libro libro)
    {
        await _unitOfWork.Libros.AddAsync(libro);
        await _unitOfWork.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = libro.Id }, libro);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Libro libro)
    {
        var existing = await _unitOfWork.Libros.GetByIdAsync(id);
        if (existing == null)
            return NotFound();

        existing.Titulo = libro.Titulo;
        existing.Anio = libro.Anio;
        existing.Genero = libro.Genero;
        existing.NumeroPaginas = libro.NumeroPaginas;
        existing.AutorId = libro.AutorId;

        _unitOfWork.Libros.Update(existing);
        await _unitOfWork.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var libro = await _unitOfWork.Libros.GetByIdAsync(id);
        if (libro == null)
            return NotFound();

        _unitOfWork.Libros.Remove(libro);
        await _unitOfWork.SaveChangesAsync();

        return NoContent();
    }
}
