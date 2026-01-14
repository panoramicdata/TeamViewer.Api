using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace TeamViewer.Api.Handlers;

/// <summary>
/// HTTP message handler that logs request and response information.
/// </summary>
public class LoggingHandler : DelegatingHandler
{
	private readonly ILogger<LoggingHandler>? _logger;

	/// <summary>
	/// Initializes a new instance of the <see cref="LoggingHandler"/> class.
	/// </summary>
	public LoggingHandler(ILogger<LoggingHandler>? logger = null)
	{
		_logger = logger;
	}

	/// <inheritdoc/>
	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		var stopwatch = Stopwatch.StartNew();
		_logger?.LogDebug("HTTP {Method} {Uri}", request.Method, request.RequestUri);

		var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

		stopwatch.Stop();
		_logger?.LogDebug("HTTP {Method} {Uri} responded {StatusCode} in {ElapsedMs}ms", request.Method, request.RequestUri, (int)response.StatusCode, stopwatch.ElapsedMilliseconds);

		return response;
	}
}
