namespace AgendaFisio.Front.Models.Auth;

public class RegistroEmpleadoRequest
{
    public string Nombre { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string CodigoRegistro { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;
}