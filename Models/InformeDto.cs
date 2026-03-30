namespace AgendaFisio.Front.Models;

public class InformeDto
{
    public long Id { get; set; }
    public long TenantId { get; set; }
    public long PacienteId { get; set; }
    public string? NombrePaciente { get; set; }
    public long? ProfesionalId { get; set; }
    public string? NombreProfesional { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string? Contenido { get; set; }
    public DateTime FechaEmisionUtc { get; set; }
    public string? ArchivoUrl { get; set; }
    public DateTime? CreatedAtUtc { get; set; }
}
