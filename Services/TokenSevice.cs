using Microsoft.JSInterop;

namespace AgendaFisio.Front.Services;

public class TokenService
{
    private readonly IJSRuntime _js;

    private const string KEY = "auth_token";

    public TokenService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task SetToken(string token)
    {
        await _js.InvokeVoidAsync("localStorage.setItem", KEY, token);
    }

    public async Task<string?> GetToken()
    {
        return await _js.InvokeAsync<string>("localStorage.getItem", KEY);
    }

    public async Task RemoveToken()
    {
        await _js.InvokeVoidAsync("localStorage.removeItem", KEY);
    }
}