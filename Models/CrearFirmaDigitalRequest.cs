namespace AgendaFisio.Front.Models;

public class CrearFirmaDigitalRequest
{
    public long PacienteId { get; set; }
    public string TipoDocumento { get; set; } = string.Empty;
    public long? DocumentoReferenciaId { get; set; }
    public string FirmaBase64 { get; set; } = string.Empty;
}
