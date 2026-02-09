using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// Interface for Socket Authentication operations.
/// Used for WebSocket real-time communication authentication.
/// </summary>
public interface ISocketAuthenticationApi
{
	/// <summary>
	/// Gets a socket authentication token.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The socket authentication token.</returns>
	[Post("/socket/authenticate")]
	Task<SocketAuthenticationToken> AuthenticateAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Validates a socket authentication token.
	/// </summary>
	/// <param name="request">The validation request containing the token.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The validation result.</returns>
	[Post("/socket/validate")]
	Task<SocketTokenValidationResult> ValidateTokenAsync(
		[Body] ValidateSocketTokenRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Revokes a socket authentication token.
	/// </summary>
	/// <param name="request">The revocation request containing the token.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Post("/socket/revoke")]
	Task RevokeTokenAsync(
		[Body] RevokeSocketTokenRequest request,
		CancellationToken cancellationToken);
}
