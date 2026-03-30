namespace AgendaFisio.Front.Models;

public class BusquedaCitaRequest
{
    public string? TextoBusqueda { get; set; }
    public long? PacienteId { get; set; }
    public long? ProfesionalId { get; set; }
    public string? Estado { get; set; }
    public DateTime? FechaDesdeUtc { get; set; }
    public DateTime? FechaHastaUtc { get; set; }
    public int Pagina { get; set; } = 1;
    public int ElementosPorPagina { get; set; } = 20;
}
