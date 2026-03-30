using System.Net.Http.Json;
using AgendaFisio.Front.Models;

namespace AgendaFisio.Front.Services;

public class NoAsistenciasApiService
{
    private readonly HttpClient _http;

    public NoAsistenciasApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<NoAsistenciaDto>> GetAllAsync(DateTime? desdeUtc = null, DateTime? hastaUtc = null)
    {
        var url = "/api/no-asistencias";
        var queryParams = new List<string>();

        if (desdeUtc.HasValue)
            queryParams.Add($"desdeUtc={Uri.EscapeDataString(desdeUtc.Value.ToString("yyyy-MM-ddTHH:mm:ss"))}");

        if (hastaUtc.HasValue)
            queryParams.Add($"hastaUtc={Uri.EscapeDataString(hastaUtc.Value.ToString("yyyy-MM-ddTHH:mm:ss"))}");

        if (queryParams.Count > 0)
            url += "?" + string.Join("&", queryParams);

        var result = await _http.GetFromJsonAsync<List<NoAsistenciaDto>>(url);
        return result ?? new List<NoAsistenciaDto>();
    }

    public async Task<List<NoAsistenciaDto>> GetByPacienteAsync(long pacienteId)
    {
        var result = await _http.GetFromJsonAsync<List<NoAsistenciaDto>>($"/api/pacientes/{pacienteId}/no-asistencias");
        return result ?? new List<NoAsistenciaDto>();
    }

    public async Task<(bool Ok, string? Error)> RegistrarAsync(long citaId, string? motivo = null, string? observaciones = null)
    {
        var response = await _http.PostAsJsonAsync("/api/no-asistencias", new
        {
            CitaId = citaId,
            Motivo = motivo,
            Observaciones = observaciones
        });

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<(bool Ok, string? Error)> JustificarAsync(long id, string observaciones)
    {
        var response = await _http.PatchAsJsonAsync($"/api/no-asistencias/{id}/justificar", new { Observaciones = observaciones });

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<bool> EliminarAsync(long id)
    {
        var response = await _http.DeleteAsync($"/api/no-asistencias/{id}");
        return response.IsSuccessStatusCode;
    }
}
