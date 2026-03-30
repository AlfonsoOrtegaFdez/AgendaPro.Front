namespace AgendaFisio.Front.Models;

public class PacienteFactorRiesgoDto
{
    public long Id { get; set; }
    public long PacienteId { get; set; }
    public long FactorRiesgoId { get; set; }
    public string? NombreFactor { get; set; }
    public string? Severidad { get; set; }
    public string? Notas { get; set; }
    public DateTime? FechaDeteccionUtc { get; set; }
}
