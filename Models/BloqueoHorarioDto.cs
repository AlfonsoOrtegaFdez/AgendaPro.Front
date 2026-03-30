namespace AgendaFisio.Front.Models;

public class BloqueoHorarioDto
{
    public long Id { get; set; }
    public long TenantId { get; set; }
    public long ProfesionalId { get; set; }
    public string? NombreProfesional { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public string Tipo { get; set; } = "Puntual";
    public DateTime FechaHoraInicioUtc { get; set; }
    public DateTime FechaHoraFinUtc { get; set; }
    public bool TodoElDia { get; set; }
    public bool Recurrente { get; set; }
    public string? PatronRecurrencia { get; set; }
    public string? Color { get; set; }
    public bool Activo { get; set; } = true;
    public DateTime? CreatedAtUtc { get; set; }

    public DateTime FechaHoraInicio =>
        DateTime.SpecifyKind(FechaHoraInicioUtc, DateTimeKind.Utc).ToLocalTime();

    public DateTime FechaHoraFin =>
        DateTime.SpecifyKind(FechaHoraFinUtc, DateTimeKind.Utc).ToLocalTime();
}
