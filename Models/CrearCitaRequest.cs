namespace AgendaFisio.Front.Models;

public sealed class CrearCitaRequest
{
    public long? ProfesionalId { get; set; }
    public long? PacienteId { get; set; }
    public long? ServicioId { get; set; }
    public long? PacienteBonoId { get; set; }

    public string? NombrePacienteTemporal { get; set; }
    public string? TelefonoPacienteTemporal { get; set; }

    public DateTime FechaHoraInicioUtc { get; set; }
    public DateTime? FechaHoraFinUtc { get; set; }

    public int? DuracionMinutos { get; set; }
    public decimal? Precio { get; set; } = default(decimal?);

    public string? Tipo { get; set; }
    public string? Motivo { get; set; }
    public string? Observaciones { get; set; }
    public string? Origen { get; set; }
    public string? Color { get; set; }
}