using Proyecto1.Domain.Interfaces;
using Proyecto1.Infrastructure.Data;

namespace Proyecto1.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context,
                      IAutorRepository autorRepository,
                      ILibroRepository libroRepository)
    {
        _context = context;
        Autores = autorRepository;
        Libros = libroRepository;
    }

    public IAutorRepository Autores { get; }
    public ILibroRepository Libros { get; }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
