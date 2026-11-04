namespace TeamViewer.Api.Handlers;

/// <summary>
/// HTTP message handler that refuses any request other than GET, HEAD or OPTIONS while <see cref="TeamViewerClientOptions.IsReadOnly"/> is set.
/// </summary>
/// <param name="options">The client options, read on every request.</param>
public class ReadOnlyHandler(TeamViewerClientOptions options) : DelegatingHandler
{
	private readonly TeamViewerClientOptions _options = options ?? throw new ArgumentNullException(nameof(options));

	/// <inheritdoc/>
	protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		if (_options.IsReadOnly
			&& request.Method != HttpMethod.Get
			&& request.Method != HttpMethod.Head
			&& request.Method != HttpMethod.Options)
		{
			throw new InvalidOperationException($"The client is read-only (IsReadOnly is true): {request.Method} requests are not allowed.");
		}

		return base.SendAsync(request, cancellationToken);
	}
}
