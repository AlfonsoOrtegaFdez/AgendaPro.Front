namespace AgendaFisio.Front.Models;

public class PacienteCampoPersonalizadoDto
{
    public long Id { get; set; }
    public long PacienteId { get; set; }
    public long CampoPersonalizadoId { get; set; }
    public string? NombreCampo { get; set; }
    public string? Valor { get; set; }
}
