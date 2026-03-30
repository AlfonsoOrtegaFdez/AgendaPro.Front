namespace AgendaFisio.Front.Models;

public class VistaMensualDiaDto
{
    public DateTime Fecha { get; set; }
    public int TotalCitas { get; set; }
    public int CitasConfirmadas { get; set; }
    public int CitasPendientes { get; set; }
    public int CitasCanceladas { get; set; }
    public int Bloqueos { get; set; }
    public bool TieneDisponibilidad { get; set; }
}
