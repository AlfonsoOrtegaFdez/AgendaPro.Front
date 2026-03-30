namespace AgendaFisio.Front.Models;

public class CrearCertificadoRequest
{
    public long PacienteId { get; set; }
    public long? ProfesionalId { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public string? Contenido { get; set; }
    public string? FirmaBase64 { get; set; }
}
