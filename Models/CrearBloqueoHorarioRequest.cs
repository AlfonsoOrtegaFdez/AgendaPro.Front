namespace AgendaFisio.Front.Models;

public class CrearBloqueoHorarioRequest
{
    public long ProfesionalId { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public string Tipo { get; set; } = "Puntual";
    public DateTime FechaHoraInicioUtc { get; set; }
    public DateTime FechaHoraFinUtc { get; set; }
    public bool TodoElDia { get; set; }
    public bool Recurrente { get; set; }
    public string? PatronRecurrencia { get; set; }
    public string? Color { get; set; }
}
