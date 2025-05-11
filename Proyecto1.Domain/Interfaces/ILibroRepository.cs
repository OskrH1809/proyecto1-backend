using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Domain.Entities;

namespace Proyecto1.Domain.Interfaces
{
    public interface ILibroRepository
    {
        Task<int> CountAsync(Expression<Func<Libro, bool>> predicate);
        Task<IEnumerable<Libro>> GetAllAsync();
        Task<Libro?> GetByIdAsync(int id);
        Task AddAsync(Libro libro);
        void Update(Libro libro);
        Task<IEnumerable<Libro>> GetAllWithAutoresAsync();

        void Remove(Libro libro);
    }
}
