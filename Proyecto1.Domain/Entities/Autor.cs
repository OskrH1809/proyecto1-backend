using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Domain.Entities
{
    internal class Autor
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string? CiudadProcedencia { get; set; }
        public string? CorreoElectronico { get; set; }

        

        public ICollection<Libro> Libros { get; set; } = new List<Libro>();
    }
}
