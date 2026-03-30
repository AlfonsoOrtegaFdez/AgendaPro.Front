using System.Net.Http.Json;
using AgendaFisio.Front.Models;

namespace AgendaFisio.Front.Services;

public class TutoresApiService
{
    private readonly HttpClient _http;

    public TutoresApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<TutorDto>> GetByPacienteAsync(long pacienteId)
    {
        var result = await _http.GetFromJsonAsync<List<TutorDto>>($"/api/pacientes/{pacienteId}/tutores");
        return result ?? new List<TutorDto>();
    }

    public async Task<TutorDto?> GetByIdAsync(long id)
    {
        return await _http.GetFromJsonAsync<TutorDto>($"/api/tutores/{id}");
    }

    public async Task<(bool Ok, string? Error)> CrearAsync(TutorDto tutor)
    {
        var response = await _http.PostAsJsonAsync("/api/tutores", tutor);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<(bool Ok, string? Error)> ActualizarAsync(TutorDto tutor)
    {
        var response = await _http.PutAsJsonAsync($"/api/tutores/{tutor.Id}", tutor);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<bool> EliminarAsync(long id)
    {
        var response = await _http.DeleteAsync($"/api/tutores/{id}");
        return response.IsSuccessStatusCode;
    }
}
