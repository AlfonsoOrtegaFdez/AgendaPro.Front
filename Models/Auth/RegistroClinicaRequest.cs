namespace AgendaFisio.Front.Models.Auth;

public class RegistroClinicaRequest
{
    public string NombreClinica { get; set; } = string.Empty;
    public string? TelefonoClinica { get; set; }
    public string? DireccionClinica { get; set; }
    public string NombreAdmin { get; set; } = string.Empty;
    public string ApellidosAdmin { get; set; } = string.Empty;
    public string EmailAdmin { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;
}