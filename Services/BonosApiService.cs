using System.Net.Http.Json;
using AgendaFisio.Front.Models;

namespace AgendaFisio.Front.Services;

public class BonosApiService
{
    private readonly HttpClient _http;

    public BonosApiService(HttpClient http)
    {
        _http = http;
    }

    // ── Catálogo de bonos ──

    public async Task<List<BonoDto>> GetAllAsync()
    {
        var result = await _http.GetFromJsonAsync<List<BonoDto>>("/api/bonos");
        return result ?? new List<BonoDto>();
    }

    public async Task<BonoDto?> GetByIdAsync(long id)
    {
        return await _http.GetFromJsonAsync<BonoDto>($"/api/bonos/{id}");
    }

    public async Task<(bool Ok, string? Error)> CrearAsync(BonoDto bono)
    {
        var response = await _http.PostAsJsonAsync("/api/bonos", bono);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<(bool Ok, string? Error)> ActualizarAsync(BonoDto bono)
    {
        var response = await _http.PutAsJsonAsync($"/api/bonos/{bono.Id}", bono);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<bool> EliminarAsync(long id)
    {
        var response = await _http.DeleteAsync($"/api/bonos/{id}");
        return response.IsSuccessStatusCode;
    }

    // ── Bonos asignados a pacientes ──

    public async Task<List<PacienteBonoDto>> GetByPacienteAsync(long pacienteId)
    {
        var result = await _http.GetFromJsonAsync<List<PacienteBonoDto>>($"/api/pacientes/{pacienteId}/bonos");
        return result ?? new List<PacienteBonoDto>();
    }

    public async Task<(bool Ok, string? Error)> AsignarAsync(AsignarBonoRequest request)
    {
        var response = await _http.PostAsJsonAsync("/api/pacientes/bonos", request);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<(bool Ok, string? Error)> ConsumirSesionAsync(long pacienteBonoId)
    {
        var response = await _http.PatchAsJsonAsync($"/api/pacientes/bonos/{pacienteBonoId}/consumir", new { });

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }
}
