namespace AgendaFisio.Front.Models;

public class AsignarBonoRequest
{
    public long PacienteId { get; set; }
    public long BonoId { get; set; }
    public DateTime? FechaExpiracionUtc { get; set; }
}
