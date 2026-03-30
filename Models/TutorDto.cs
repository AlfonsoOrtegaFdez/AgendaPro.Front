namespace AgendaFisio.Front.Models;

public class TutorDto
{
    public long Id { get; set; }
    public long PacienteId { get; set; }
    public string? NombrePaciente { get; set; }
    public string NombreTutor { get; set; } = string.Empty;
    public string? ApellidosTutor { get; set; }
    public string? DniTutor { get; set; }
    public string? TelefonoTutor { get; set; }
    public string? EmailTutor { get; set; }
    public string? Parentesco { get; set; }
    public string? Observaciones { get; set; }
    public DateTime? CreatedAtUtc { get; set; }
}
