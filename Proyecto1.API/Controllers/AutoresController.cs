using Microsoft.AspNetCore.Mvc;
using Proyecto1.Domain.Entities;
using Proyecto1.Domain.Interfaces;

namespace Proyecto1.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutoresController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public AutoresController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var autores = await _unitOfWork.Autores.GetAllAsync();
        return Ok(autores);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var autor = await _unitOfWork.Autores.GetByIdAsync(id);
        if (autor == null)
            return NotFound();

        return Ok(autor);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Autor autor)
    {
        await _unitOfWork.Autores.AddAsync(autor);
        await _unitOfWork.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = autor.Id }, autor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Autor autor)
    {
        var existing = await _unitOfWork.Autores.GetByIdAsync(id);
        if (existing == null)
            return NotFound();

        existing.NombreCompleto = autor.NombreCompleto;
        existing.FechaNacimiento = autor.FechaNacimiento;
        existing.CiudadProcedencia = autor.CiudadProcedencia;
        existing.CorreoElectronico = autor.CorreoElectronico;

        _unitOfWork.Autores.Update(existing);
        await _unitOfWork.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var autor = await _unitOfWork.Autores.GetByIdAsync(id);
        if (autor == null)
            return NotFound();

        _unitOfWork.Autores.Remove(autor);
        await _unitOfWork.SaveChangesAsync();

        return NoContent();
    }
}
