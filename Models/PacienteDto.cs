namespace AgendaFisio.Front.Models;

public class PacienteDto
{
    public long Id { get; set; }
    public long TenantId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public DateOnly? FechaNacimiento { get; set; }
    public string? Observaciones { get; set; }
    public bool Activo { get; set; } = true;
    public DateTime? CreatedAtUtc { get; set; }
}