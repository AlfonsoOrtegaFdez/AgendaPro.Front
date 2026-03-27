using Microsoft.JSInterop;

namespace AgendaFisio.Front.Services;

public class SessionService
{
    private readonly IJSRuntime _js;

    private const string RolKey = "user_rol";
    private const string NombreKey = "user_nombre";
    private const string ClinicaKey = "user_clinica";

    public SessionService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task SetSession(string rol, string nombre, string nombreClinica)
    {
        await _js.InvokeVoidAsync("localStorage.setItem", RolKey, rol);
        await _js.InvokeVoidAsync("localStorage.setItem", NombreKey, nombre);
        await _js.InvokeVoidAsync("localStorage.setItem", ClinicaKey, nombreClinica);
    }

    public async Task<string?> GetRol()
    {
        return await _js.InvokeAsync<string?>("localStorage.getItem", RolKey);
    }

    public async Task<string?> GetNombre()
    {
        return await _js.InvokeAsync<string?>("localStorage.getItem", NombreKey);
    }

    public async Task<string?> GetNombreClinica()
    {
        return await _js.InvokeAsync<string?>("localStorage.getItem", ClinicaKey);
    }

    public async Task Clear()
    {
        await _js.InvokeVoidAsync("localStorage.removeItem", RolKey);
        await _js.InvokeVoidAsync("localStorage.removeItem", NombreKey);
        await _js.InvokeVoidAsync("localStorage.removeItem", ClinicaKey);
    }
}
