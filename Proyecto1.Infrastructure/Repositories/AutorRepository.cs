using Microsoft.EntityFrameworkCore;
using Proyecto1.Domain.Entities;
using Proyecto1.Domain.Interfaces;
using Proyecto1.Infrastructure.Data;

namespace Proyecto1.Infrastructure.Repositories;

public class AutorRepository : IAutorRepository
{
    private readonly AppDbContext _context;

    public AutorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Autor>> GetAllAsync()
    {
        return await _context.Autores.ToListAsync();
    }

    public async Task<Autor?> GetByIdAsync(int id)
    {
        return await _context.Autores.FindAsync(id);
    }

    public async Task AddAsync(Autor autor)
    {
        await _context.Autores.AddAsync(autor);
    }

    public void Update(Autor autor)
    {
        _context.Autores.Update(autor);
    }

    public void Remove(Autor autor)
    {
        _context.Autores.Remove(autor);
    }
}
