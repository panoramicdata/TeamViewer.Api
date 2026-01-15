using System.Net.Http.Headers;

namespace TeamViewer.Api.Handlers;

/// <summary>
/// HTTP message handler that adds Bearer token authentication to requests.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="AuthenticationHandler"/> class.
/// </remarks>
/// <param name="scriptToken">The TeamViewer script token.</param>
public class AuthenticationHandler(string scriptToken) : DelegatingHandler
{
	private readonly string _scriptToken = scriptToken ?? throw new ArgumentNullException(nameof(scriptToken));

	/// <inheritdoc/>
	protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _scriptToken);
		return base.SendAsync(request, cancellationToken);
	}
}
