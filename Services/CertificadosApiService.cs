using System.Net.Http.Json;
using AgendaFisio.Front.Models;

namespace AgendaFisio.Front.Services;

public class CertificadosApiService
{
    private readonly HttpClient _http;

    public CertificadosApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<CertificadoDto>> GetByPacienteAsync(long pacienteId)
    {
        var result = await _http.GetFromJsonAsync<List<CertificadoDto>>($"/api/pacientes/{pacienteId}/certificados");
        return result ?? new List<CertificadoDto>();
    }

    public async Task<CertificadoDto?> GetByIdAsync(long id)
    {
        return await _http.GetFromJsonAsync<CertificadoDto>($"/api/certificados/{id}");
    }

    public async Task<(bool Ok, string? Error)> CrearAsync(CrearCertificadoRequest request)
    {
        var response = await _http.PostAsJsonAsync("/api/certificados", request);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<(bool Ok, string? Error)> FirmarAsync(long id, string firmaBase64)
    {
        var response = await _http.PatchAsJsonAsync($"/api/certificados/{id}/firmar", new { FirmaBase64 = firmaBase64 });

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<bool> EliminarAsync(long id)
    {
        var response = await _http.DeleteAsync($"/api/certificados/{id}");
        return response.IsSuccessStatusCode;
    }
}
