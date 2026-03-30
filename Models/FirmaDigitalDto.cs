namespace AgendaFisio.Front.Models;

public class FirmaDigitalDto
{
    public long Id { get; set; }
    public long TenantId { get; set; }
    public long PacienteId { get; set; }
    public string? NombrePaciente { get; set; }
    public string TipoDocumento { get; set; } = string.Empty;
    public long? DocumentoReferenciaId { get; set; }
    public string? FirmaBase64 { get; set; }
    public string? IpFirma { get; set; }
    public DateTime FechaFirmaUtc { get; set; }
    public DateTime? CreatedAtUtc { get; set; }
}
