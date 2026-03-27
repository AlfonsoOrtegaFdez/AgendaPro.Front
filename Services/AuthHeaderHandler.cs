using System.Net.Http.Headers;

namespace AgendaFisio.Front.Services;

public sealed class AuthHeaderHandler : DelegatingHandler
{
    private readonly TokenService _tokenService;

    public AuthHeaderHandler(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token = await _tokenService.GetToken();

        if (!string.IsNullOrWhiteSpace(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}