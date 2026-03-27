using System.Net.Http.Json;
using AgendaFisio.Front.Models;

namespace AgendaFisio.Front.Services;

public class CitasApiService
{
    private readonly HttpClient _http;

    public CitasApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<DashboardCitaDto>> GetSemanaAsync(DateTime desde, DateTime hasta, long? profesionalId = null)
    {
        var desdeStr = Uri.EscapeDataString(desde.ToString("yyyy-MM-ddTHH:mm:ss"));
        var hastaStr = Uri.EscapeDataString(hasta.ToString("yyyy-MM-ddTHH:mm:ss"));

        var url = $"/api/citas?desdeUtc={desdeStr}&hastaUtc={hastaStr}";

        if (profesionalId.HasValue)
            url += $"&profesionalId={profesionalId.Value}";

        var result = await _http.GetFromJsonAsync<List<DashboardCitaDto>>(url);
        return result ?? new List<DashboardCitaDto>();
    }

    public async Task<List<DashboardCitaDto>> GetDiaAsync(DateTime fecha, long? profesionalId = null)
    {
        return await GetSemanaAsync(
            fecha.Date,
            fecha.Date.AddDays(1).AddSeconds(-1),
            profesionalId);
    }

    public async Task<(bool Ok, string? Error)> CrearAsync(CrearCitaRequest request)
    {
        var response = await _http.PostAsJsonAsync("/api/citas", request);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<(bool Ok, string? Error)> CambiarEstadoAsync(long id, string nuevoEstado)
    {
        var response = await _http.PatchAsJsonAsync($"/api/citas/{id}/estado", new { Estado = nuevoEstado });

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<bool> EliminarAsync(long id)
    {
        var response = await _http.DeleteAsync($"/api/citas/{id}");
        return response.IsSuccessStatusCode;
    }
}