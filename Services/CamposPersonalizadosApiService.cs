using System.Net.Http.Json;
using AgendaFisio.Front.Models;

namespace AgendaFisio.Front.Services;

public class CamposPersonalizadosApiService
{
    private readonly HttpClient _http;

    public CamposPersonalizadosApiService(HttpClient http)
    {
        _http = http;
    }

    // ── Definición de campos ──

    public async Task<List<CampoPersonalizadoDto>> GetAllAsync()
    {
        var result = await _http.GetFromJsonAsync<List<CampoPersonalizadoDto>>("/api/campos-personalizados");
        return result ?? new List<CampoPersonalizadoDto>();
    }

    public async Task<(bool Ok, string? Error)> CrearAsync(CampoPersonalizadoDto campo)
    {
        var response = await _http.PostAsJsonAsync("/api/campos-personalizados", campo);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<(bool Ok, string? Error)> ActualizarAsync(CampoPersonalizadoDto campo)
    {
        var response = await _http.PutAsJsonAsync($"/api/campos-personalizados/{campo.Id}", campo);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<bool> EliminarAsync(long id)
    {
        var response = await _http.DeleteAsync($"/api/campos-personalizados/{id}");
        return response.IsSuccessStatusCode;
    }

    // ── Valores por paciente ──

    public async Task<List<PacienteCampoPersonalizadoDto>> GetByPacienteAsync(long pacienteId)
    {
        var result = await _http.GetFromJsonAsync<List<PacienteCampoPersonalizadoDto>>($"/api/pacientes/{pacienteId}/campos-personalizados");
        return result ?? new List<PacienteCampoPersonalizadoDto>();
    }

    public async Task<(bool Ok, string? Error)> GuardarValoresAsync(long pacienteId, List<PacienteCampoPersonalizadoDto> valores)
    {
        var response = await _http.PutAsJsonAsync($"/api/pacientes/{pacienteId}/campos-personalizados", valores);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }
}
