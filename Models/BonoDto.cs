namespace AgendaFisio.Front.Models;

public class BonoDto
{
    public long Id { get; set; }
    public long TenantId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public long? ServicioId { get; set; }
    public string? NombreServicio { get; set; }
    public int TotalSesiones { get; set; }
    public decimal Precio { get; set; }
    public bool Activo { get; set; } = true;
    public DateTime? CreatedAtUtc { get; set; }
}
