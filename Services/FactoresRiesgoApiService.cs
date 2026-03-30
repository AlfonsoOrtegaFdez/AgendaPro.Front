using System.Net.Http.Json;
using AgendaFisio.Front.Models;

namespace AgendaFisio.Front.Services;

public class FactoresRiesgoApiService
{
    private readonly HttpClient _http;

    public FactoresRiesgoApiService(HttpClient http)
    {
        _http = http;
    }

    // ── Catálogo de factores de riesgo ──

    public async Task<List<FactorRiesgoDto>> GetAllAsync()
    {
        var result = await _http.GetFromJsonAsync<List<FactorRiesgoDto>>("/api/factores-riesgo");
        return result ?? new List<FactorRiesgoDto>();
    }

    public async Task<FactorRiesgoDto?> GetByIdAsync(long id)
    {
        return await _http.GetFromJsonAsync<FactorRiesgoDto>($"/api/factores-riesgo/{id}");
    }

    public async Task<(bool Ok, string? Error)> CrearAsync(FactorRiesgoDto factor)
    {
        var response = await _http.PostAsJsonAsync("/api/factores-riesgo", factor);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<(bool Ok, string? Error)> ActualizarAsync(FactorRiesgoDto factor)
    {
        var response = await _http.PutAsJsonAsync($"/api/factores-riesgo/{factor.Id}", factor);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<bool> EliminarAsync(long id)
    {
        var response = await _http.DeleteAsync($"/api/factores-riesgo/{id}");
        return response.IsSuccessStatusCode;
    }

    // ── Factores asignados a pacientes ──

    public async Task<List<PacienteFactorRiesgoDto>> GetByPacienteAsync(long pacienteId)
    {
        var result = await _http.GetFromJsonAsync<List<PacienteFactorRiesgoDto>>($"/api/pacientes/{pacienteId}/factores-riesgo");
        return result ?? new List<PacienteFactorRiesgoDto>();
    }

    public async Task<(bool Ok, string? Error)> AsignarAsync(long pacienteId, long factorRiesgoId, string? notas = null)
    {
        var response = await _http.PostAsJsonAsync($"/api/pacientes/{pacienteId}/factores-riesgo",
            new { FactorRiesgoId = factorRiesgoId, Notas = notas });

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<bool> DesasignarAsync(long pacienteId, long factorRiesgoId)
    {
        var response = await _http.DeleteAsync($"/api/pacientes/{pacienteId}/factores-riesgo/{factorRiesgoId}");
        return response.IsSuccessStatusCode;
    }
}
