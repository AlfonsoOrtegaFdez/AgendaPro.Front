using System.Net.Http.Json;
using AgendaFisio.Front.Models;

namespace AgendaFisio.Front.Services;

public class ProfesionalesApiService
{
    private readonly HttpClient _http;

    public ProfesionalesApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<ProfesionalDto>> GetAllAsync()
    {
        var result = await _http.GetFromJsonAsync<List<ProfesionalDto>>("/api/profesionales");
        return result ?? new List<ProfesionalDto>();
    }
}
