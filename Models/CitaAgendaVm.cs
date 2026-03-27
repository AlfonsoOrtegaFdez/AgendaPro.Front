namespace AgendaFisio.Front.Models;

public class CitaAgendaVm
{
    public int Id { get; set; }
    public int ProfesionalId { get; set; }
    public string PacienteNombre { get; set; } = "";
    public string Servicio { get; set; } = "";
    public string Estado { get; set; } = "";
    public DateTime FechaHoraInicio { get; set; }
    public DateTime FechaHoraFin { get; set; }
}