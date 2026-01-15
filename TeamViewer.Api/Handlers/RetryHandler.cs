using System.Net;
using Microsoft.Extensions.Logging;

namespace TeamViewer.Api.Handlers;

/// <summary>
/// HTTP message handler that implements retry logic with exponential backoff.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="RetryHandler"/> class.
/// </remarks>
public class RetryHandler(
	int maxRetries,
	int baseDelayMs,
	ILogger logger) : DelegatingHandler
{
	private static readonly HttpStatusCode[] RetryableStatusCodes =
	[
		HttpStatusCode.RequestTimeout,
		HttpStatusCode.TooManyRequests,
		HttpStatusCode.InternalServerError,
		HttpStatusCode.BadGateway,
		HttpStatusCode.ServiceUnavailable,
		HttpStatusCode.GatewayTimeout
	];

	/// <inheritdoc/>
	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		HttpResponseMessage? response = null;
		for (var attempt = 0; attempt <= maxRetries; attempt++)
		{
			if (attempt > 0)
			{
				var delay = baseDelayMs * (int)Math.Pow(2, attempt - 1);
				logger?.LogWarning("Retry attempt {Attempt} after {Delay}ms", attempt, delay);
				await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
			}

			try
			{
				response = await base.SendAsync(CloneRequest(request), cancellationToken).ConfigureAwait(false);
				if (!ShouldRetry(response.StatusCode) || attempt == maxRetries)
				{
					return response;
				}
			}
			catch (HttpRequestException) when (attempt < maxRetries)
			{
				logger?.LogWarning("Request failed, will retry");
			}
		}

		return response!;
	}

	private static bool ShouldRetry(HttpStatusCode statusCode) => Array.Exists(RetryableStatusCodes, s => s == statusCode);

	private static HttpRequestMessage CloneRequest(HttpRequestMessage request)
	{
		var clone = new HttpRequestMessage(request.Method, request.RequestUri) { Version = request.Version };
		foreach (var header in request.Headers)
		{
			clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
		}

		if (request.Content != null)
		{
			clone.Content = request.Content;
		}

		return clone;
	}
}
