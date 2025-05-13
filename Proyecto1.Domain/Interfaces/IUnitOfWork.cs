using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAutorRepository Autores { get; }
        ILibroRepository Libros { get; }

        Task<int> SaveChangesAsync();
    }
}
