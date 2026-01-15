namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for session code management.
/// </summary>
public interface ISessionsApi
{
	/// <summary>
	/// Gets a list of session codes.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of sessions.</returns>
	[Get("/sessions")]
	Task<SessionListResponse> GetAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a specific session by code.
	/// </summary>
	/// <param name="sessionCode">The session code.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The session.</returns>
	[Get("/sessions/{sessionCode}")]
	Task<Session> GetAsync(
		string sessionCode,
		CancellationToken cancellationToken);

	/// <summary>
	/// Creates a new session code.
	/// </summary>
	/// <param name="request">The create session request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created session.</returns>
	[Post("/sessions")]
	Task<Session> CreateAsync(
		[Body] CreateSessionRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Modifies an existing session code.
	/// </summary>
	/// <param name="sessionCode">The session code.</param>
	/// <param name="request">The update session request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Put("/sessions/{sessionCode}")]
	Task UpdateAsync(
		string sessionCode,
		[Body] UpdateSessionRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Deletes a session code.
	/// </summary>
	/// <param name="sessionCode">The session code.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/sessions/{sessionCode}")]
	Task DeleteAsync(
		string sessionCode,
		CancellationToken cancellationToken);
}
