using System.Net.Http.Json;
using AgendaFisio.Front.Models;

namespace AgendaFisio.Front.Services;

public class FiltrosAgendaApiService
{
    private readonly HttpClient _http;

    public FiltrosAgendaApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<FiltroAgendaDto>> GetMisFiltrosAsync()
    {
        var result = await _http.GetFromJsonAsync<List<FiltroAgendaDto>>("/api/filtros-agenda");
        return result ?? new List<FiltroAgendaDto>();
    }

    public async Task<FiltroAgendaDto?> GetPredeterminadoAsync()
    {
        return await _http.GetFromJsonAsync<FiltroAgendaDto>("/api/filtros-agenda/predeterminado");
    }

    public async Task<(bool Ok, string? Error)> CrearAsync(FiltroAgendaDto filtro)
    {
        var response = await _http.PostAsJsonAsync("/api/filtros-agenda", filtro);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<(bool Ok, string? Error)> ActualizarAsync(FiltroAgendaDto filtro)
    {
        var response = await _http.PutAsJsonAsync($"/api/filtros-agenda/{filtro.Id}", filtro);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<bool> EliminarAsync(long id)
    {
        var response = await _http.DeleteAsync($"/api/filtros-agenda/{id}");
        return response.IsSuccessStatusCode;
    }
}
