using System.Net.Http.Json;
using AgendaFisio.Front.Models;

namespace AgendaFisio.Front.Services;

public class PlanningApiService
{
    private readonly HttpClient _http;

    public PlanningApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<PlanningDiarioDto?> GetPlanningDiarioAsync(DateTime fecha, long? profesionalId = null)
    {
        var fechaStr = Uri.EscapeDataString(fecha.ToString("yyyy-MM-dd"));
        var url = $"/api/planning/diario?fecha={fechaStr}";

        if (profesionalId.HasValue)
            url += $"&profesionalId={profesionalId.Value}";

        return await _http.GetFromJsonAsync<PlanningDiarioDto>(url);
    }

    public async Task<List<VistaMensualDiaDto>> GetVistaMensualAsync(int anio, int mes, long? profesionalId = null)
    {
        var url = $"/api/planning/mensual?anio={anio}&mes={mes}";

        if (profesionalId.HasValue)
            url += $"&profesionalId={profesionalId.Value}";

        var result = await _http.GetFromJsonAsync<List<VistaMensualDiaDto>>(url);
        return result ?? new List<VistaMensualDiaDto>();
    }
}
