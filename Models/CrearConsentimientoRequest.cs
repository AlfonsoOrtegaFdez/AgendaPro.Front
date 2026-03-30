namespace AgendaFisio.Front.Models;

public class CrearConsentimientoRequest
{
    public long PacienteId { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string? Contenido { get; set; }
    public string? FirmaBase64 { get; set; }
}
