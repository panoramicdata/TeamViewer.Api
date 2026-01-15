using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for WebConnector session management.
/// </summary>
public interface IWebConnectorApi
{
	/// <summary>
	/// Gets a list of WebConnector sessions.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of WebConnector sessions.</returns>
	[Get("/webconnector/sessions")]
	Task<WebConnectorSessionListResponse> GetSessionsAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Creates a new WebConnector session.
	/// </summary>
	/// <param name="request">The create session request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created WebConnector session.</returns>
	[Post("/webconnector/sessions")]
	Task<WebConnectorSession> CreateSessionAsync(
		[Body] CreateWebConnectorSessionRequest request,
		CancellationToken cancellationToken);
}
