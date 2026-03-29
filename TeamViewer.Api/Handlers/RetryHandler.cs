using System.Net;

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
		for (var attempt = 0; attempt <= maxRetries; attempt++)
		{
            await DelayBeforeRetryAsync(attempt, cancellationToken).ConfigureAwait(false);

			var response = await SendAttemptAsync(request, attempt, cancellationToken).ConfigureAwait(false);
			if (response is not null)
			{
                return response;
			}
		}

       throw new InvalidOperationException("Retry handler did not return a response.");
	}

 private async Task DelayBeforeRetryAsync(int attempt, CancellationToken cancellationToken)
	{
		if (attempt == 0)
		{
			return;
		}

		var delay = baseDelayMs * (int)Math.Pow(2, attempt - 1);
		logger?.LogWarning("Retry attempt {Attempt} after {Delay}ms", attempt, delay);
		await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
	}

	private async Task<HttpResponseMessage?> SendAttemptAsync(HttpRequestMessage request, int attempt, CancellationToken cancellationToken)
	{
		try
		{
			var response = await base.SendAsync(CloneRequest(request), cancellationToken).ConfigureAwait(false);
			return ShouldRetry(response.StatusCode) && attempt < maxRetries
				? null
				: response;
		}
		catch (HttpRequestException) when (attempt < maxRetries)
		{
			logger?.LogWarning("Request failed, will retry");
			return null;
		}
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
