namespace AgendaFisio.Front.Models;

public class CampoPersonalizadoDto
{
    public long Id { get; set; }
    public long TenantId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string TipoCampo { get; set; } = "Texto";
    public string? Opciones { get; set; }
    public bool Obligatorio { get; set; }
    public int Orden { get; set; }
    public bool Activo { get; set; } = true;
    public DateTime? CreatedAtUtc { get; set; }
}
