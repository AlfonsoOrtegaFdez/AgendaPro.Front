using Microsoft.JSInterop;
using System.Text.Json;

namespace AgendaFisio.Front.Services;

public class EstadoCitaCacheService
{
    private readonly IJSRuntime _js;
    private const string CacheKey = "cita_estado_cache";

    public EstadoCitaCacheService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task GuardarEstadoAsync(long citaId, string estado)
    {
        var cache = await ObtenerCacheAsync();
        cache[citaId.ToString()] = estado;
        await EscribirCacheAsync(cache);
    }

    public async Task EliminarEstadoAsync(long citaId)
    {
        var cache = await ObtenerCacheAsync();
        cache.Remove(citaId.ToString());
        await EscribirCacheAsync(cache);
    }

    public async Task<Dictionary<string, string>> ObtenerCacheAsync()
    {
        try
        {
            var json = await _js.InvokeAsync<string?>("localStorage.getItem", CacheKey);
            if (!string.IsNullOrWhiteSpace(json))
                return JsonSerializer.Deserialize<Dictionary<string, string>>(json) ?? new();
        }
        catch { }

        return new();
    }

    public async Task AplicarCacheAsync(List<Models.DashboardCitaDto> citas)
    {
        var cache = await ObtenerCacheAsync();
        if (cache.Count == 0) return;

        foreach (var cita in citas)
        {
            if (cache.TryGetValue(cita.Id.ToString(), out var estado))
            {
                cita.Estado = estado;
            }
        }
    }

    private async Task EscribirCacheAsync(Dictionary<string, string> cache)
    {
        var json = JsonSerializer.Serialize(cache);
        await _js.InvokeVoidAsync("localStorage.setItem", CacheKey, json);
    }
}
