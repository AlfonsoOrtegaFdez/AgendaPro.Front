using System.Net.Http.Json;
using AgendaFisio.Front.Models;

namespace AgendaFisio.Front.Services;

public class ConsentimientosApiService
{
    private readonly HttpClient _http;

    public ConsentimientosApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<ConsentimientoDto>> GetByPacienteAsync(long pacienteId)
    {
        var result = await _http.GetFromJsonAsync<List<ConsentimientoDto>>($"/api/pacientes/{pacienteId}/consentimientos");
        return result ?? new List<ConsentimientoDto>();
    }

    public async Task<ConsentimientoDto?> GetByIdAsync(long id)
    {
        return await _http.GetFromJsonAsync<ConsentimientoDto>($"/api/consentimientos/{id}");
    }

    public async Task<(bool Ok, string? Error)> CrearAsync(CrearConsentimientoRequest request)
    {
        var response = await _http.PostAsJsonAsync("/api/consentimientos", request);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<(bool Ok, string? Error)> FirmarAsync(long id, string firmaBase64)
    {
        var response = await _http.PatchAsJsonAsync($"/api/consentimientos/{id}/firmar", new { FirmaBase64 = firmaBase64 });

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<bool> EliminarAsync(long id)
    {
        var response = await _http.DeleteAsync($"/api/consentimientos/{id}");
        return response.IsSuccessStatusCode;
    }
}
