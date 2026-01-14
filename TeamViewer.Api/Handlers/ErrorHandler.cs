using System.Net;
using System.Text.Json;
using TeamViewer.Api.Exceptions;

namespace TeamViewer.Api.Handlers;

/// <summary>
/// HTTP message handler that converts error responses to exceptions.
/// </summary>
public class ErrorHandler : DelegatingHandler
{
	/// <inheritdoc/>
	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

		if (response.IsSuccessStatusCode)
			return response;

		var content = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
		string? errorMessage = null;

		try
		{
			using var doc = JsonDocument.Parse(content);
			if (doc.RootElement.TryGetProperty("error", out var error))
				errorMessage = error.GetString();
			else if (doc.RootElement.TryGetProperty("error_description", out var desc))
				errorMessage = desc.GetString();
		}
		catch (JsonException)
		{
			errorMessage = content;
		}

		throw new TeamViewerApiException(response.StatusCode, errorMessage ?? "An unknown error occurred", content);
	}
}
