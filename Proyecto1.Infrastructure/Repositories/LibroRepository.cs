using Microsoft.EntityFrameworkCore;
using Proyecto1.Domain.Entities;
using Proyecto1.Domain.Interfaces;
using Proyecto1.Infrastructure.Data;

namespace Proyecto1.Infrastructure.Repositories;

public class LibroRepository : ILibroRepository
{
    private readonly AppDbContext _context;

    public LibroRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Libro>> GetAllAsync()
    {
        return await _context.Libros.ToListAsync();
    }

    public async Task<Libro?> GetByIdAsync(int id)
    {
        return await _context.Libros.FindAsync(id);
    }

    public async Task AddAsync(Libro libro)
    {
        await _context.Libros.AddAsync(libro);
    }

    public void Update(Libro libro)
    {
        _context.Libros.Update(libro);
    }

    public void Remove(Libro libro)
    {
        _context.Libros.Remove(libro);
    }
}
