using System.Net.Http.Json;
using AgendaFisio.Front.Models;

namespace AgendaFisio.Front.Services;

public class InformesApiService
{
    private readonly HttpClient _http;

    public InformesApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<InformeDto>> GetByPacienteAsync(long pacienteId)
    {
        var result = await _http.GetFromJsonAsync<List<InformeDto>>($"/api/informes/paciente/{pacienteId}");
        return result ?? new List<InformeDto>();
    }

    public async Task<InformeDto?> GetByIdAsync(long id)
    {
        return await _http.GetFromJsonAsync<InformeDto>($"/api/informes/{id}");
    }

    public async Task<(bool Ok, string? Error)> CrearAsync(CrearInformeRequest request)
    {
        var response = await _http.PostAsJsonAsync("/api/informes", request);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} - {body}");
    }

    public async Task<(bool Ok, string? Error)> ActualizarAsync(InformeDto informe)
    {
        var response = await _http.PutAsJsonAsync($"/api/informes/{informe.Id}", informe);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} - {body}");
    }

    public async Task<bool> EliminarAsync(long id)
    {
        var response = await _http.DeleteAsync($"/api/informes/{id}");
        return response.IsSuccessStatusCode;
    }
}