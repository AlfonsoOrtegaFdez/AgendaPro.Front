namespace AgendaFisio.Front.Models;

public class FactorRiesgoDto
{
    public long Id { get; set; }
    public long TenantId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public string? Severidad { get; set; }
    public bool Activo { get; set; } = true;
    public DateTime? CreatedAtUtc { get; set; }
}
