using AgendaFisio.Front.Models;
using System.Net.Http.Json;

public sealed class AgendaApiService
{
    private readonly HttpClient _httpClient;

    public AgendaApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<AgendaCitaDto>> GetSemanaAsync(DateTime desdeUtc, DateTime hastaUtc, long? profesionalId)
    {
        var desde = Uri.EscapeDataString(desdeUtc.ToString("yyyy-MM-ddTHH:mm:ss"));
        var hasta = Uri.EscapeDataString(hastaUtc.ToString("yyyy-MM-ddTHH:mm:ss"));

        var url = $"api/agenda/semana?desdeUtc={desde}&hastaUtc={hasta}";

        if (profesionalId.HasValue)
            url += $"&profesionalId={profesionalId.Value}";

        var result = await _httpClient.GetFromJsonAsync<List<AgendaCitaDto>>(url);
        return result ?? new List<AgendaCitaDto>();
    }
}