using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace TeamViewer.Api.Handlers;

/// <summary>
/// HTTP message handler that logs request and response information.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="LoggingHandler"/> class.
/// </remarks>
internal class LoggingHandler(ILogger? logger) : DelegatingHandler
{

	/// <inheritdoc/>
	protected override async Task<HttpResponseMessage> SendAsync(
		HttpRequestMessage request,
		CancellationToken cancellationToken)
	{
		if (logger is null)
		{
			return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
		}

		var stopwatch = Stopwatch.StartNew();

		// Only do this if the debug level is enabled to avoid unnecessary string formatting
		if (logger.IsEnabled(LogLevel.Debug))
		{
			// Same as above, but log headers and content if debug is enabled
			logger.LogDebug(
				"Request Headers: {Headers}\nContent: {Content}",
				request.Headers.ToString(),
				request.Content != null
					? await request
						.Content
						.ReadAsStringAsync(cancellationToken)
						.ConfigureAwait(false)
					: "<no content>"
				);
		}

		var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

		stopwatch.Stop();

		// Only do this if the debug level is enabled to avoid unnecessary string formatting
		if (logger.IsEnabled(LogLevel.Debug))
		{
			logger.LogDebug(
				"HTTP {Method} {Uri} responded {StatusCode} in {ElapsedMs}ms\nHeaders: {Headers}\nContent: {Content}",
				request.Method,
				request.RequestUri,
				(int)response.StatusCode,
				stopwatch.ElapsedMilliseconds,
				response.Headers.ToString(),
				response.Content != null
					? await response.Content
						.ReadAsStringAsync(cancellationToken)
						.ConfigureAwait(false)
					: "<no content>"
			);
		}

		return response;
	}
}
