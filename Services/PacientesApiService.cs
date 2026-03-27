using System.Net.Http.Json;
using AgendaFisio.Front.Models;

namespace AgendaFisio.Front.Services;

public class PacientesApiService
{
    private readonly HttpClient _http;

    public PacientesApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<PacienteDto>> GetAllAsync()
    {
        var result = await _http.GetFromJsonAsync<List<PacienteDto>>("/api/pacientes");
        return result ?? new List<PacienteDto>();
    }

    public async Task<PacienteDto?> GetByIdAsync(long id)
    {
        return await _http.GetFromJsonAsync<PacienteDto>($"/api/pacientes/{id}");
    }

    public async Task<(bool Ok, string? Error)> CrearAsync(PacienteDto paciente)
    {
        var response = await _http.PostAsJsonAsync("/api/pacientes", paciente);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<(bool Ok, string? Error)> ActualizarAsync(PacienteDto paciente)
    {
        var response = await _http.PutAsJsonAsync($"/api/pacientes/{paciente.Id}", paciente);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<bool> EliminarAsync(long id)
    {
        var response = await _http.DeleteAsync($"/api/pacientes/{id}");
        return response.IsSuccessStatusCode;
    }
}