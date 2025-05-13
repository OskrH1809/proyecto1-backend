namespace Proyecto1.Application.DTOs;

public class AutorDto
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = null!;
    public DateTime FechaNacimiento { get; set; }
    public string? CiudadProcedencia { get; set; }
    public string? CorreoElectronico { get; set; }
}
