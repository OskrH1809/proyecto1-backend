namespace Proyecto1.Application.DTOs;

public class LibroDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = null!;
    public int Anio { get; set; }
    public string? Genero { get; set; }
    public int NumeroPaginas { get; set; }
    public int AutorId { get; set; }

}
