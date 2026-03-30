using System.Net.Http.Json;
using System.Text.Json.Nodes;
using AgendaFisio.Front.Models;

namespace AgendaFisio.Front.Services;

public class CitasApiService
{
    private readonly HttpClient _http;

    public CitasApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<DashboardCitaDto>> GetSemanaAsync(DateTime desde, DateTime hasta, long? profesionalId = null)
    {
        var desdeStr = Uri.EscapeDataString(desde.ToString("yyyy-MM-ddTHH:mm:ss"));
        var hastaStr = Uri.EscapeDataString(hasta.ToString("yyyy-MM-ddTHH:mm:ss"));

        var url = $"/api/citas?desdeUtc={desdeStr}&hastaUtc={hastaStr}";

        if (profesionalId.HasValue)
            url += $"&profesionalId={profesionalId.Value}";

        var result = await _http.GetFromJsonAsync<List<DashboardCitaDto>>(url);
        return result ?? new List<DashboardCitaDto>();
    }

    public async Task<List<DashboardCitaDto>> GetDiaAsync(DateTime fecha, long? profesionalId = null)
    {
        return await GetSemanaAsync(
            fecha.Date,
            fecha.Date.AddDays(1).AddSeconds(-1),
            profesionalId);
    }

    public async Task<(bool Ok, string? Error)> CrearAsync(CrearCitaRequest request)
    {
        var response = await _http.PostAsJsonAsync("/api/citas", request);

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }

    public async Task<(bool Ok, string? Error)> CambiarEstadoAsync(long id, string nuevoEstado)
    {
        // Estrategia 1: GET completo + modificar estado + PUT (más fiable)
        var getResponse = await _http.GetAsync($"/api/citas/{id}");
        if (getResponse.IsSuccessStatusCode)
        {
            var json = await getResponse.Content.ReadAsStringAsync();
            var node = JsonNode.Parse(json);
            if (node is JsonObject obj)
            {
                // Detectar casing del campo estado y actualizarlo
                if (obj.ContainsKey("estado"))
                    obj["estado"] = nuevoEstado.ToLowerInvariant();
                else if (obj.ContainsKey("Estado"))
                    obj["Estado"] = nuevoEstado;
                else
                    obj["estado"] = nuevoEstado.ToLowerInvariant();

                var content = new StringContent(
                    obj.ToJsonString(),
                    System.Text.Encoding.UTF8,
                    "application/json");

                var putResponse = await _http.PutAsync($"/api/citas/{id}", content);
                if (putResponse.IsSuccessStatusCode)
                    return (true, null);

                var putBody = await putResponse.Content.ReadAsStringAsync();
                return (false, $"{(int)putResponse.StatusCode} – {putBody}");
            }
        }

        // Estrategia 2: PATCH directo al recurso
        var patchResponse = await _http.PatchAsJsonAsync(
            $"/api/citas/{id}",
            new { estado = nuevoEstado.ToLowerInvariant() });

        if (patchResponse.IsSuccessStatusCode)
            return (true, null);

        var body = await patchResponse.Content.ReadAsStringAsync();
        return (false, $"{(int)patchResponse.StatusCode} – {body}");
    }

    public async Task<bool> EliminarAsync(long id)
    {
        var response = await _http.DeleteAsync($"/api/citas/{id}");
        return response.IsSuccessStatusCode;
    }

    // ── Buscador de citas ──

    public async Task<BusquedaCitaResultDto?> BuscarAsync(BusquedaCitaRequest request)
    {
        var queryParams = new List<string>();

        if (!string.IsNullOrWhiteSpace(request.TextoBusqueda))
            queryParams.Add($"texto={Uri.EscapeDataString(request.TextoBusqueda)}");

        if (request.PacienteId.HasValue)
            queryParams.Add($"pacienteId={request.PacienteId.Value}");

        if (request.ProfesionalId.HasValue)
            queryParams.Add($"profesionalId={request.ProfesionalId.Value}");

        if (!string.IsNullOrWhiteSpace(request.Estado))
            queryParams.Add($"estado={Uri.EscapeDataString(request.Estado)}");

        if (request.FechaDesdeUtc.HasValue)
            queryParams.Add($"desdeUtc={Uri.EscapeDataString(request.FechaDesdeUtc.Value.ToString("yyyy-MM-ddTHH:mm:ss"))}");

        if (request.FechaHastaUtc.HasValue)
            queryParams.Add($"hastaUtc={Uri.EscapeDataString(request.FechaHastaUtc.Value.ToString("yyyy-MM-ddTHH:mm:ss"))}");

        queryParams.Add($"pagina={request.Pagina}");
        queryParams.Add($"elementosPorPagina={request.ElementosPorPagina}");

        var url = "/api/citas/buscar?" + string.Join("&", queryParams);
        return await _http.GetFromJsonAsync<BusquedaCitaResultDto>(url);
    }

    // ── Cambio de profesional ──

    public async Task<(bool Ok, string? Error)> CambiarProfesionalAsync(CambiarProfesionalRequest request)
    {
        var response = await _http.PatchAsJsonAsync($"/api/citas/{request.CitaId}/profesional", new
        {
            request.NuevoProfesionalId,
            request.Motivo
        });

        if (response.IsSuccessStatusCode)
            return (true, null);

        var body = await response.Content.ReadAsStringAsync();
        return (false, $"{(int)response.StatusCode} – {body}");
    }
}