using System.Linq.Expressions;
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
    public async Task<IEnumerable<Libro>> BuscarPorTextoAsync(string? query)
    {
        var libros = _context.Libros
            .Include(l => l.Autor)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(query))
        {
            query = query.ToLower();
            libros = libros.Where(l =>
                l.Titulo.ToLower().Contains(query) ||
                l.Autor.NombreCompleto.ToLower().Contains(query) ||
                l.Anio.ToString().Contains(query));
        }

        return await libros.ToListAsync();
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
    public async Task<int> CountAsync(Expression<Func<Libro, bool>> predicate)
    {
        return await _context.Libros.CountAsync(predicate);
    }
    public async Task<IEnumerable<Libro>> GetAllWithAutoresAsync()
    {
        return await _context.Libros.Include(l => l.Autor).ToListAsync();
    }

    public void Remove(Libro libro)
    {
        _context.Libros.Remove(libro);
    }
}
