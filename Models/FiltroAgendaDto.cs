namespace AgendaFisio.Front.Models;

public class FiltroAgendaDto
{
    public long Id { get; set; }
    public long TenantId { get; set; }
    public long ProfesionalId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public List<long> ProfesionalesVisibles { get; set; } = new();
    public List<string> DiasVisibles { get; set; } = new();
    public string VistaPreferida { get; set; } = "Semanal";
    public bool SoloMisCitas { get; set; }
    public bool MostrarBloqueos { get; set; } = true;
    public bool MostrarCanceladas { get; set; }
    public bool EsPredeterminado { get; set; }
    public DateTime? CreatedAtUtc { get; set; }
}
