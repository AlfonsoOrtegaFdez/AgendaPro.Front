namespace AgendaFisio.Front.Models;

public class NoAsistenciaDto
{
    public long Id { get; set; }
    public long CitaId { get; set; }
    public long PacienteId { get; set; }
    public string? NombrePaciente { get; set; }
    public long? ProfesionalId { get; set; }
    public string? NombreProfesional { get; set; }
    public DateTime FechaCitaUtc { get; set; }
    public string? Motivo { get; set; }
    public bool Justificada { get; set; }
    public string? Observaciones { get; set; }
    public DateTime? CreatedAtUtc { get; set; }

    public DateTime FechaCita =>
        DateTime.SpecifyKind(FechaCitaUtc, DateTimeKind.Utc).ToLocalTime();
}
