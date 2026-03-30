namespace AgendaFisio.Front.Models;

public class CambiarProfesionalRequest
{
    public long CitaId { get; set; }
    public long NuevoProfesionalId { get; set; }
    public string? Motivo { get; set; }
}
