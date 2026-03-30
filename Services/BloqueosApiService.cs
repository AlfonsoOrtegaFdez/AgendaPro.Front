using System.Net.Http.Json;
using AgendaFisio.Front.Models;

namespace AgendaFisio.Front.Services;

public class BloqueosApiService
{
    private readonly HttpClient _http;

    public BloqueosApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<BloqueoHorarioDto>> GetByProfesionalAsync(long profesionalId, DateTime? desdeUtc = null, DateTime? hastaUtc = null)
    {
        var url = $"/api/profesionales/{profesionalId}/bloqueos";

        if (desdeUtc.HasValue && hastaUtc.HasValue)
        {
            var desde = Uri.EscapeDataString(desdeUtc.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            var hasta = Uri.EscapeDataString(hastaUtc.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            url += $"?desdeUtc={desde}&hastaUtc={hasta}";
        }

        var result = await _http.GetFromJsonAsync<List<BloqueoHorarioDto>>(url);
        return result ?? new List<BloqueoHorarioDto>();
    }

    public async Task<List<BloqueoHorarioDto>> GetAllAsync(DateTime desdeUtc, DateTime hastaUtc)
    {
        var desde = Uri.EscapeDataString(desdeUtc.ToString("yyyy-MM-ddTHH:mm:ss"));
        var hasta = Uri.EscapeDataString(hastaUtc.ToString("yyyy-MM-ddTHH:mm:ss"));

        var result = await _http.GetFromJsonAsync<List<BloqueoHorarioDto>>($"/api/bloqueos?desdeUtc={desde}&hastaUtc={hasta}");
        return result ?? new List<BloqueoHorarioDto>();
    }

    public async Task<BloqueoHorarioDto?> GetByIdAsync(long id)
    {
        return await _http.GetFromJsonAsync<BloqueoHorarioDto>($"/api/bloqueos/{id}");
    }

    public async Task<(bool Ok, string? Error)> CrearAsync(CrearBloqueoHorarioRequest request)
    {
        var response = await _http.PostAsJsonAsync("/api/bloqueos", request);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<(bool Ok, string? Error)> ActualizarAsync(BloqueoHorarioDto bloqueo)
    {
        var response = await _http.PutAsJsonAsync($"/api/bloqueos/{bloqueo.Id}", bloqueo);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<bool> EliminarAsync(long id)
    {
        var response = await _http.DeleteAsync($"/api/bloqueos/{id}");
        return response.IsSuccessStatusCode;
    }
}
