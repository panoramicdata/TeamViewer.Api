using System.Net;

namespace TeamViewer.Api.Exceptions;

/// <summary>
/// Exception thrown when the TeamViewer API returns an error response.
/// </summary>
public class TeamViewerApiException : Exception
{
	/// <summary>
	/// Gets the HTTP status code from the API response.
	/// </summary>
	public HttpStatusCode StatusCode { get; }

	/// <summary>
	/// Gets the raw response content from the API.
	/// </summary>
	public string? ResponseContent { get; }

	/// <summary>
	/// Initializes a new instance of the <see cref="TeamViewerApiException"/> class.
	/// </summary>
	public TeamViewerApiException(HttpStatusCode statusCode, string message, string? responseContent = null)
		: base(message)
	{
		StatusCode = statusCode;
		ResponseContent = responseContent;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="TeamViewerApiException"/> class.
	/// </summary>
	public TeamViewerApiException(HttpStatusCode statusCode, string message, Exception innerException)
		: base(message, innerException)
	{
		StatusCode = statusCode;
	}
}
