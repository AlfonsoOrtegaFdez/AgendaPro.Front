namespace AgendaFisio.Front.Models;

public class DashboardCitaDto
{
    public long Id { get; set; }

    public long? ProfesionalId { get; set; }
    public long? PacienteId { get; set; }

    public DateTime FechaHoraInicioUtc { get; set; }
    public DateTime FechaHoraFinUtc { get; set; }

    public string? NombrePacienteTemporal { get; set; }
    public string? TelefonoPacienteTemporal { get; set; }

    public decimal Precio { get; set; }
    public string Estado { get; set; } = string.Empty;
    public string? Tipo { get; set; }
    public string? Motivo { get; set; }
    public string? Observaciones { get; set; }
    public string? Color { get; set; }

    public bool TienePago { get; set; }
    public string? EstadoPago { get; set; }

    public string PacienteNombre =>
        !string.IsNullOrWhiteSpace(NombrePacienteTemporal)
            ? NombrePacienteTemporal
            : "Paciente";

    public string Telefono =>
        TelefonoPacienteTemporal ?? string.Empty;

    public DateTime FechaHoraInicio =>
        DateTime.SpecifyKind(FechaHoraInicioUtc, DateTimeKind.Utc).ToLocalTime();

    public DateTime FechaHoraFin =>
        DateTime.SpecifyKind(FechaHoraFinUtc, DateTimeKind.Utc).ToLocalTime();

    public string ProfesionalNombre => string.Empty;
    public string ServicioNombre => string.Empty;
}