namespace AgendaFisio.Front.Models;

public class PlanningDiarioDto
{
    public DateTime Fecha { get; set; }
    public int TotalCitas { get; set; }
    public int CitasConfirmadas { get; set; }
    public int CitasPendientes { get; set; }
    public int CitasCanceladas { get; set; }
    public int Bloqueos { get; set; }
    public List<DashboardCitaDto> Citas { get; set; } = new();
    public List<BloqueoHorarioDto> BloqueoHorarios { get; set; } = new();
    public List<ProfesionalResumenDto> Profesionales { get; set; } = new();
}
