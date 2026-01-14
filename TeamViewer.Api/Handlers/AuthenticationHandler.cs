using System.Net.Http.Headers;

namespace TeamViewer.Api.Handlers;

/// <summary>
/// HTTP message handler that adds Bearer token authentication to requests.
/// </summary>
public class AuthenticationHandler : DelegatingHandler
{
	private readonly string _scriptToken;

	/// <summary>
	/// Initializes a new instance of the <see cref="AuthenticationHandler"/> class.
	/// </summary>
	/// <param name="scriptToken">The TeamViewer script token.</param>
	public AuthenticationHandler(string scriptToken)
	{
		_scriptToken = scriptToken ?? throw new ArgumentNullException(nameof(scriptToken));
	}

	/// <inheritdoc/>
	protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _scriptToken);
		return base.SendAsync(request, cancellationToken);
	}
}
