namespace AgendaFisio.Front.Models;

public class ProfesionalResumenDto
{
    public long ProfesionalId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int TotalCitas { get; set; }
    public int Bloqueos { get; set; }
}
