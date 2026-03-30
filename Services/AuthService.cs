using AgendaFisio.Front.Models.Auth;
using AgendaFisio.Models.Auth;
using System.Net.Http.Json;

namespace AgendaFisio.Front.Services;

public class AuthService
{
    private readonly HttpClient _http;
    private readonly TokenService _tokenService;
    private readonly SessionService _sessionService;

    public AuthService(HttpClient http, TokenService tokenService, SessionService sessionService)
    {
        _http = http;
        _tokenService = tokenService;
        _sessionService = sessionService;
    }

    public async Task<LoginResponse?> Login(string email, string password)
    {
        var response = await _http.PostAsJsonAsync("/api/auth/login", new
        {
            email,
            password
        });

        if (!response.IsSuccessStatusCode)
            return null;

        var data = await response.Content.ReadFromJsonAsync<LoginResponse>();

        if (data is null || string.IsNullOrWhiteSpace(data.Token))
            return null;

        await _tokenService.SetToken(data.Token);
        await _sessionService.SetSession(data.Rol, $"{data.Nombre} {data.Apellidos}", data.NombreClinica);

        if (data.ProfesionalId.HasValue)
            await _sessionService.SetProfesionalId(data.ProfesionalId.Value);

        return data;
    }

    public async Task<RegistroClinicaResponse?> RegistrarClinica(RegistroClinicaRequest request)
    {
        var response = await _http.PostAsJsonAsync("/api/auth/registro-clinica", request);

        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<RegistroClinicaResponse>();
    }

    public async Task<RegistroEmpleadoResponse?> RegistrarEmpleado(RegistroEmpleadoRequest request)
    {
        var response = await _http.PostAsJsonAsync("/api/auth/registro-empleado", request);

        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<RegistroEmpleadoResponse>();
    }
}

