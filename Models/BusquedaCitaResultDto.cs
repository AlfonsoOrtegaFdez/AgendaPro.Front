namespace AgendaFisio.Front.Models;

public class BusquedaCitaResultDto
{
    public List<DashboardCitaDto> Citas { get; set; } = new();
    public int TotalResultados { get; set; }
    public int Pagina { get; set; }
    public int TotalPaginas { get; set; }
}
