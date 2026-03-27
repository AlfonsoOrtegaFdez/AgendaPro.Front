namespace AgendaFisio.Front.Models.Auth;

public class RegistroEmpleadoResponse
{
    public string Mensaje { get; set; } = string.Empty;
    public string Tenant { get; set; } = string.Empty;
    public string Usuario { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;
}