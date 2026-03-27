namespace AgendaFisio.Front.Models;

public class AgendaCitaDto
{
    public int Id { get; set; }

    public int ProfesionalId { get; set; }
    public string ProfesionalNombre { get; set; } = string.Empty;

    public int PacienteId { get; set; }
    public string PacienteNombre { get; set; } = string.Empty;

    public string ServicioNombre { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;

    public DateTime FechaHoraInicio { get; set; }
    public DateTime FechaHoraFin { get; set; }

    public string? Telefono { get; set; }
}