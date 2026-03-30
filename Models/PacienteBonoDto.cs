namespace AgendaFisio.Front.Models;

public class PacienteBonoDto
{
    public long Id { get; set; }
    public long PacienteId { get; set; }
    public string? NombrePaciente { get; set; }
    public long BonoId { get; set; }
    public string? NombreBono { get; set; }
    public int SesionesTotales { get; set; }
    public int SesionesUsadas { get; set; }
    public int SesionesRestantes => SesionesTotales - SesionesUsadas;
    public decimal PrecioTotal { get; set; }
    public bool Activo { get; set; } = true;
    public DateTime? FechaCompraUtc { get; set; }
    public DateTime? FechaExpiracionUtc { get; set; }
}
