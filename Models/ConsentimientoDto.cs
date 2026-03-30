namespace AgendaFisio.Front.Models;

public class ConsentimientoDto
{
    public long Id { get; set; }
    public long TenantId { get; set; }
    public long PacienteId { get; set; }
    public string? NombrePaciente { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string? Contenido { get; set; }
    public bool Firmado { get; set; }
    public DateTime? FechaFirmaUtc { get; set; }
    public string? FirmaBase64 { get; set; }
    public string? ArchivoUrl { get; set; }
    public DateTime? CreatedAtUtc { get; set; }
}
