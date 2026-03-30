using System.Net.Http.Json;
using AgendaFisio.Front.Models;

namespace AgendaFisio.Front.Services;

public class FirmaDigitalApiService
{
    private readonly HttpClient _http;

    public FirmaDigitalApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<FirmaDigitalDto>> GetByPacienteAsync(long pacienteId)
    {
        var result = await _http.GetFromJsonAsync<List<FirmaDigitalDto>>($"/api/pacientes/{pacienteId}/firmas");
        return result ?? new List<FirmaDigitalDto>();
    }

    public async Task<FirmaDigitalDto?> GetByIdAsync(long id)
    {
        return await _http.GetFromJsonAsync<FirmaDigitalDto>($"/api/firmas/{id}");
    }

    public async Task<(bool Ok, string? Error)> CrearAsync(CrearFirmaDigitalRequest request)
    {
        var response = await _http.PostAsJsonAsync("/api/firmas", request);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }
}
