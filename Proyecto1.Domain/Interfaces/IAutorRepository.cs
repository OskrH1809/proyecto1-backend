using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Domain.Entities;

namespace Proyecto1.Domain.Interfaces
{
    public interface IAutorRepository
    {
        Task<IEnumerable<Autor>> GetAllAsync();
        Task<Autor?> GetByIdAsync(int id);
        Task AddAsync(Autor autor);
        void Update(Autor autor);
        void Remove(Autor autor);

    }
}
