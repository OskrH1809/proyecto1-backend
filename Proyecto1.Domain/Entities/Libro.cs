using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Domain.Entities
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public int Anio { get; set; }
        public string? Genero { get; set; }
        public int? NumeroPaginas { get; set; }


        public int AutorId { get; set; }
        public Autor Autor { get; set; } = null!;
    }
}
