namespace AgendaFisio.Front.Models;

public class CrearInformeRequest
{
    public long PacienteId { get; set; }
    public long ProfesionalId { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Contenido { get; set; } = string.Empty;
    public string? Tipo { get; set; }
}