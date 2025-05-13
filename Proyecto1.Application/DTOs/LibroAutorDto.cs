using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Application.DTOs
{
    public class LibroAutorDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public int Anio { get; set; }
        public string? Genero { get; set; }
        public int NumeroPaginas { get; set; }
        public int AutorId { get; set; }
        public string NombreAutor { get; set; } = null!;
    }

}
